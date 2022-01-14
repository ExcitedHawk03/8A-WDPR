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
        
        private Account _currentUser;
        
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

        public IActionResult privateChatRoom(){
            var chats = _context.chat
                        .Include(c => c.Users)
                        .ThenInclude(cu => cu.account)
                        .Where(u => u.ruimte == chatRuimte.prive 
                        && u.Users.Any(s => s.AccountId == User.FindFirst(ClaimTypes.NameIdentifier).Value))
                        .ToList();

            return View(chats);
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

        public IActionResult chatSelection(){
            var currentPersoon = _context.accounts.FirstOrDefault(a => a.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if(currentPersoon.typAccount != "Ouder" && currentPersoon.typAccount != "moderator" && currentPersoon.blocked == false)
                return View(_context.chat.Include(c => c.Users).ToList());
            else if (currentPersoon.typAccount == "moderator")
                return RedirectToAction("moderatorChatSelection");
            else
                return View("index", "Home");
        }

        public IActionResult moderatorChatSelection(){
                return View(_context.chat.Include(c => c.Users).ToList());
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
                currentTime = DateTime.Now
            };
            _context.message.Add(Message);
            await _context.SaveChangesAsync();
            return RedirectToAction("ChatRoom", new {Id = chatId});
        }

        [HttpPost]
        public async Task<IActionResult> chatSelection(string name){
            var chat = new Chat{
               naam = name,
               ruimte = chatRuimte.Room 
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

            _context.message.Add(Message);
            await _context.SaveChangesAsync();

            await _chat.Clients.Group(roomName).SendAsync("RecieveMessage", new{
                text = Message.text,
                naam = Message.naam,
                currentTime = Message.currentTime.ToString("dd/mm/yyyy hh:mm")
            });
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> MisbruikMelden(int chatId, string roomName){
            
            var abuseMessage = new Message {
                ChatId = chatId,
                naam = "er is misbruik gemeld bij de kamer",
                text = roomName,
                currentTime = DateTime.Now,
                typMessage = "abuse"
            };

            _context.message.Add(abuseMessage);
            await _context.SaveChangesAsync();

            return RedirectToAction("chatRoom", new {id = chatId});
        }

        public async Task<IActionResult> GebruikerBlokkeren(string userId){
            _context.accounts.FirstOrDefault(a => a.Id == userId).blocked = !_context.accounts.FirstOrDefault(a => a.Id == userId).blocked;
            await _context.SaveChangesAsync();
            return RedirectToAction("moderatorChatSelection");
        }
    }
}