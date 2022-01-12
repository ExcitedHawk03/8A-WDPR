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

        public Account currentAccount;


        public HomeController(UserManager<Account> AccountManager, SignInManager<Account> signInManager, ClientContext context){
            _AccountManager = AccountManager;
            _signInManager = signInManager;
            _context = context;
        }
        

        public IActionResult Index()
        {
            return View();
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
        public async Task<IActionResult> Register(string voornaam,string tussenvoegsel, string achternaam, int leeftijd,string geslacht, string email,string telnr,string postcode, string plaats, string password, string adres){                                   
            var account = new Account{
                Tussenvoegsel = tussenvoegsel,
                Achternaam = achternaam,
                Leeftijd = leeftijd,
                Email = email,
                Telnr = telnr,
                Postcode = postcode,
                Plaats = plaats,
                UserName = voornaam,
                Adres = adres
            };
            var result = await _AccountManager.CreateAsync(account, password);
            if(result.Succeeded){

                var result2 = await _signInManager.PasswordSignInAsync(account.UserName, password, false, false);

                if(result2.Succeeded){
                    currentAccount = account;
                    return RedirectToAction("chat/chatSelection");
                }
            
        }
        return RedirectToAction("register");
        }
     
        public IActionResult Register(){

             return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password){

           var user = await _AccountManager.FindByNameAsync(username);
           if(user != null){
           var result = await _signInManager.PasswordSignInAsync(user, password, false,false); 
                if(result.Succeeded){
                   return RedirectToAction("chat/chatSelection");
                }
           }
            return RedirectToAction("login");
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

        public IActionResult AfspraakMaken ()
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

        public IActionResult OuderFormulier()
        {
            return View();
        }


    }

}
