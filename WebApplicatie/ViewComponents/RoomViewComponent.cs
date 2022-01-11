using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicatie.ViewComponents{
    public class RoomViewComponent: ViewComponent
    {
        private ClientContext _context;

        public RoomViewComponent(ClientContext context){
            _context = context;
        }
         public IViewComponentResult Invoke()
        {
            var chats = _context.chat.ToList();
            return View(chats);
        }
    }
}