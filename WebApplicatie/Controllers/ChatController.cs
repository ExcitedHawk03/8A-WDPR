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

        public ChatController(UserManager<Account> AccountManager, ClientContext context, IHubContext<chatHub> chat){
            _context = context;
            _AccountManager = AccountManager;
            _chat = chat;
        }

        public IActionResult Find(){
            var users = _context.Users
                            .Where(u => u.Id != User.FindFirst(ClaimTypes.NameIdentifier).Value)
                            .Include(cu => cu.Chats)
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
            var chat = new Chat {
                ruimte = chatRuimte.prive,
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
            Console.WriteLine(User.FindFirst(ClaimTypes.NameIdentifier).Value);
            return View(_context.chat.Include(c => c.Users).ToList());
        }
        [HttpGet("{Id}")]
        public IActionResult chatRoom(int Id){
            var chat = _context.chat.Include(c => c.Messages).FirstOrDefault(c => c.Id == Id);
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
            
             //chat.Users.Add(_context.accounts.SingleOrDefault(a => a.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value));
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
                currentTime = DateTime.Now
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
    }
}