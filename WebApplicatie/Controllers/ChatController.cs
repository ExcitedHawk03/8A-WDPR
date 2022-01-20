using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using WebApplicatie.Hubs;
using WebApplicatie.Models;

namespace WebApplicatie.Controllers{
    [Authorize]
    public class ChatController : Controller
    {
        private ClientContext _context;
        private UserManager<Account> _AccountManager;

        private IHubContext<chatHub> _chat;
        
        public static Account _currentUser;
        
        public ChatController(UserManager<Account> AccountManager, ClientContext context, IHubContext<chatHub> chat){
            _context = context;
            _AccountManager = AccountManager;
            _chat = chat;        
        }
        public IActionResult Find(){
            var users = _context.Users
                            .Include(a => a.Chats)
                            .ThenInclude(cu => cu.chat)
                            .ToList();
            return View(users);
        }

        public IActionResult privateChatRoom(string Id){
            var currentPersoon = _context.accounts.FirstOrDefault(a => a.Id == Id);
            if (currentPersoon.typAccount != "client")
            {
            var chats = _context.chat
                        .Include(c => c.Users)
                        .ThenInclude(cu => cu.account)
                        .Where(u => u.ruimte == chatRuimte.prive 
                        && u.Users.Any(s => s.AccountId == User.FindFirst(ClaimTypes.NameIdentifier).Value))
                        .ToList();
                        return View(chats);
            } else {
                return RedirectToAction("CreatePrivateRoom", new {userId = 
                                        _context.hulpverlener.FirstOrDefault(h => h.Id == 
                                        _context.cliënt.FirstOrDefault(c => c.Id == currentPersoon.Id).hulpverlener.Id).Id});
            }
        }

        public async Task<IActionResult> CreatePrivateRoom(string userId){
            string currentUserId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var chat = new Chat {
                ruimte = chatRuimte.prive,
                naam = _context.accounts.FirstOrDefault(a => a.Id == userId).UserName + " chat met " + _context.accounts.FirstOrDefault(a => a.Id == currentUserId).UserName
            };

            chat.Users.Add(new ChatUser{
                AccountId = userId
            });

            chat.Users.Add(new ChatUser{
                AccountId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            });

            _context.chat.Add(chat);
            await _context.SaveChangesAsync();
            return RedirectToAction("chatRoom", new {id = chat.Id});
        }

        

        public IActionResult moderatorChatSelection(){
                return View(_context.message.Where(m => m.typMessage == "abuse").Include(m => m.chat).ThenInclude(c => c.Users).ThenInclude(u => u.account).ToList());
        }

        [HttpGet("{Id}")]
        public IActionResult chatRoom(int Id){
            var chat = _context.chat.Include(c => c.Messages).Include(c => c.Users).ThenInclude(cu => cu.account).FirstOrDefault(c => c.Id == Id);
            if(_context.accounts.FirstOrDefault(a => a.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value).typAccount == "moderator")
            {  
                var chatuser = new ChatUser{
                    ChatId = Id,
                    AccountId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    account = _context.accounts.FirstOrDefault(a => a.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value),
                    chat = chat
                };
                chat.Users.Add(chatuser);
            }
            return View(chat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int chatId, string message){
            var Message = new Message {
                ChatId = chatId,
                text = message,
                naam = User.Identity.Name,
                currentTime = DateTime.Now,
                typMessage = "chat"
            };
            _context.message.Add(Message);
            await _context.SaveChangesAsync();
            return RedirectToAction("ChatRoom", new {Id = chatId});
        }

        public IActionResult searchSelection(string SelectionKamer, int? SelectionLeeftijd){
            return RedirectToAction("chatSelection", new {naamKamer = SelectionKamer, leeftijdGroep = SelectionLeeftijd});
        }
        public IActionResult chatSelection(string naamKamer, int? leeftijdGroep){
            var currentPersoon = _context.accounts.FirstOrDefault(a => a.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);        
            switch (currentPersoon.typAccount){
                case "moderator":
                return RedirectToAction("moderatorChatSelection");
                case "ouder":
                Console.WriteLine(_context.ouder.FirstOrDefault(o => o.Id == currentPersoon.Id).kinderen.messageFrequency);
                return View("index", "Home");
                default:
                if (naamKamer != null && leeftijdGroep != null)
                    return View(_context.chat.Where(c => c.ageGroup+1 <= leeftijdGroep && c.ageGroup-1 >= leeftijdGroep && c.naam.Contains(naamKamer)).Include(c => c.Users).ToList());
                if (leeftijdGroep != null)
                    return View(_context.chat.Where(c => c.ageGroup+1 <= leeftijdGroep && c.ageGroup-1 >= leeftijdGroep).Include(c => c.Users).ToList());
                if (naamKamer != null)
                    return View(_context.chat.Where(c => c.naam.Contains(naamKamer)).Include(c => c.Users).ToList()); 
                else
                    return View(_context.chat.Include(c => c.Users).ToList());

            }
        }

        [HttpPost]
        public async Task<IActionResult> chatSelection(int ageGroup, string name ){
            var chat = new Chat{
               naam = name,
               ruimte = chatRuimte.Room,
               ageGroup = ageGroup
            };

            chat.Users.Add(new ChatUser{
                ChatId = chat.Id,
                AccountId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            });
            
            _context.chat.Add(chat);
            await _context.SaveChangesAsync();
            return RedirectToAction("chatSelection");
        }

        [HttpGet]
        public async Task<IActionResult> joinRoom(int id){
            var chatuser = new ChatUser {
                ChatId = id,
                AccountId = User.FindFirst(ClaimTypes.NameIdentifier).Value
            };
            _context.chatUsers.Add(chatuser);
            _context.chat.FirstOrDefault(c => c.Id == id).Users.Add(chatuser);
            await _context.SaveChangesAsync();
            return RedirectToAction("chatRoom", new {id = id});
        }

        [HttpPost("[controller]/[action]/{connectionId}/{roomName}")]
        public async Task<IActionResult> JoinChat(string connectionId, string roomName){
            await _chat.Groups.AddToGroupAsync(connectionId, roomName);
            return Ok();
        }
        [HttpPost("[controller]/[action]/{connectionId}/{roomName}")]
        public async Task<IActionResult> LeaveRoom(string connectionId, string roomName){
            await _chat.Groups.RemoveFromGroupAsync(connectionId, roomName);
            return Ok();
        }
        [HttpPost("[controller]/[action]")]
        public async Task<IActionResult> SendMessage(int chatId,string message, string roomName){

            var Message = new Message {
                ChatId = chatId,
                text = message,
                naam = User.Identity.Name,
                currentTime = DateTime.Now,
                typMessage = "chat"
            };
            _context.cliënt.FirstOrDefault(a => a.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value).messageFrequency++;
            _context.message.Add(Message);
            await _context.SaveChangesAsync();

            await _chat.Clients.Group(roomName).SendAsync("RecieveMessage", new{
                text = Message.text,
                naam = Message.naam,
                currentTime = Message.currentTime.ToString("dd/mm/yyyy hh:mm")
            });
            return Ok();
        }

        public async Task<IActionResult> MisbruikMelden(int chatId, bool isAbuse){
            if (isAbuse)
            {
                 _context.message.FirstOrDefault(m => m.ChatId == chatId).typMessage = "abuse";
                 await _context.SaveChangesAsync();
                 return RedirectToAction("chatRoom", new {id = chatId});
            }
            else  
                _context.message.FirstOrDefault(m => m.ChatId == chatId).typMessage = "chat";         
            await _context.SaveChangesAsync();
            return RedirectToAction("moderatorChatSelection");
        }

        public async Task<IActionResult> GebruikerBlokkeren(string userId){
            _context.accounts.FirstOrDefault(a => a.Id == userId).blocked = !_context.accounts.FirstOrDefault(a => a.Id == userId).blocked;
            await _context.SaveChangesAsync();
            return RedirectToAction("moderatorChatSelection");
        }

        
    }
}