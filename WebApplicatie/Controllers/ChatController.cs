using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicatie.Models;

namespace WebApplicatie.Controllers{
    public class ChatController : Controller
    {
        private ClientContext _context;

        public ChatController(ClientContext context){
            _context = context;
        }
        public IActionResult chatSelection(){
            
            return View(_context.chat.ToList());
        }
        [HttpGet("{Id}")]
        public IActionResult chat(int Id){
            var chat = _context.chat.Include(c => c.Messages).FirstOrDefault(c => c.Id == Id);
            return View(chat);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(int chatId, string message){
            var Message = new Message {
                ChatId = chatId,
                text = message,
                naam = "null and void",
                currentTime = DateTime.Now
            };
            _context.message.Add(Message);
            await _context.SaveChangesAsync();
            return RedirectToAction("Chat", new {Id = chatId});
        }

        [HttpPost]
        public async Task<IActionResult> chatSelection(string name){
            _context.chat.Add(new Chat{
               naam = name,
               ruimte = chatRuimte.Room 
            });
            await _context.SaveChangesAsync();
            return RedirectToAction("chatSelection");
        }
    }
}