using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicatie.Models;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace WebApplicatie.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<Account> _AccountManager;
        private readonly SignInManager<Account> _signInManager;
        private readonly ClientContext _context;



        public HomeController(UserManager<Account> AccountManager, SignInManager<Account> signInManager, ClientContext context){
            _AccountManager = AccountManager;
            _signInManager = signInManager;
            _context = context;
        }
        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Homepagina ()
        {
            return View(_context.hulpverlener.Include(h => h.cliënten).FirstOrDefault(a => a.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Authorize]
        public IActionResult Secret(){
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(string voornaam,string tussenvoegsel, string achternaam, DateTime leeftijd,string geslacht, string email,
        string telnr,string postcode, string plaats, string password, string adres, string hulpverlener, string typAccount, string Kind, bool isOuder){                                   
            var account = new Account{
                Tussenvoegsel = tussenvoegsel,
                Achternaam = achternaam,
                Leeftijd = leeftijd,
                Email = email,
                Telnr = telnr,
                Postcode = postcode,
                Plaats = plaats,
                UserName = voornaam + achternaam,
                Adres = adres,
                blocked = false,
                aangemeldeHulpverlener = hulpverlener,
                Voornaam = voornaam,
                typAccount = typAccount

            };
                if (Kind != null)
                    account.typAccount = "ouder";
                else if(typAccount == null)
                    account.typAccount = "gast";
                var serializedParent = JsonConvert.SerializeObject(account); 
                var rnd = new Random(); 
            if(!_context.accounts.Any()){
                account.typAccount = "admin";
            }   

            switch(account.typAccount){
                case "hulpverlener" :           
                hulpverlener newHulpverlener  = JsonConvert.DeserializeObject<hulpverlener>(serializedParent);
                newHulpverlener.chatNummer = rnd.Next(100,999);
                await _AccountManager.CreateAsync(newHulpverlener, password); 
                break;

                case "ouder":
                ouder newOuder = JsonConvert.DeserializeObject<ouder>(serializedParent);
                var kindc = _context.cliënt.FirstOrDefault(a => a.Id == Kind);
                newOuder.kinderen = kindc;
                await _AccountManager.CreateAsync(newOuder, password); 
                _context.cliënt.FirstOrDefault(a => a.Id == Kind).ouder = _context.ouder.FirstOrDefault(o => o.Id == newOuder.Id); 
                await _context.SaveChangesAsync();
                return RedirectToAction("Homepagina","Home");

                default:
                await _AccountManager.CreateAsync(account, password);
                break;
            }
            
                var result2 = await _signInManager.PasswordSignInAsync(account.UserName, password, false, false);

                if(result2 != null){
                if(result2.Succeeded){
                    ChatController._currentUser = account;
                    return RedirectToAction("Bevestiging","Home");
                }
                }
        return RedirectToAction("register");
        }
     
        public IActionResult Register(string typRegister){
            switch (typRegister){
                case null : return View(_context.accounts.Where(a => a.typAccount == "hulpverlener" && a.typAccount != "moderator").ToList());
                case "Ouder": return View(_context.accounts.Where(a => a.typAccount != "hulpverlener" && a.typAccount != "moderator").ToList());
            }
             return View(_context.accounts.Where(a => a.typAccount == "hulpverlener" && a.typAccount != "moderator").ToList());
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password){
           var userId = _context.accounts.FirstOrDefault(a => a.UserName == username)?.Id ?? "1";
           var user = await _AccountManager.FindByIdAsync(userId);
           if(user != null){
           var result = await _signInManager.PasswordSignInAsync(user.UserName, password, false,false); 
                if(result.Succeeded && (user.typAccount.Equals("gast"))){
                    ChatController._currentUser = user;
                   return RedirectToAction("Create","Aanmelding");
                }
           }
            return RedirectToAction("Homepagina", "Home");
        }
         public IActionResult Login(){
          return View();
         }
        

        public async Task<IActionResult> logout(){
            await _signInManager.SignOutAsync();
             return RedirectToAction("index");
        }
    
        public IActionResult Orthopedagogen()
        {
            return View();
        }

        public IActionResult AanmeldingIntake ()
        {
            return View();
        }

        public IActionResult Ouder()
        {
            return View();
        }

         public IActionResult Ouderlogin()
        {
            return View();
        }


        public IActionResult Contact ()
        {
            return View();
        }

        public IActionResult clienten (){
            return View(_context.accounts.Where(a => a.typAccount == "gast").ToList());
        }

        [HttpPost]
        public async Task<IActionResult> clienten(string Id, bool afkeuren){
            if(afkeuren)
            {
                _context.accounts.Remove(_context.accounts.FirstOrDefault(a => a.Id == Id));
                await _context.SaveChangesAsync();
            }
            _context.accounts.FirstOrDefault(a => a.Id == Id).typAccount = "client";
            var serializedParent = JsonConvert.SerializeObject(_context.accounts.FirstOrDefault(a => a.Id == Id));
            _context.accounts.Remove(_context.accounts.FirstOrDefault(a => a.Id == Id));
            client client =  JsonConvert.DeserializeObject<client>(serializedParent);
            client.hulpverlener = _context.hulpverlener.FirstOrDefault(a => a.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value);
            _context.cliënt.Add(client);
            await _context.SaveChangesAsync();
            _context.hulpverlener.Include(h => h.cliënten).FirstOrDefault(h => h.Id == User.FindFirst(ClaimTypes.NameIdentifier).Value).cliënten.Add(client);
            return RedirectToAction("Homepagina");
        }

        public IActionResult hulpverleneraanmeldingen(){
            return View(_context.hulpverlener.Include(h => h.cliënten).ToList());
        }

        public IActionResult Bevestiging()
        {
            return View();
        }

    }

}
