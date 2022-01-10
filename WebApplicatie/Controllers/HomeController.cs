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

namespace WebApplicatie.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _AccountManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        static Account currentAccount;


        public HomeController(UserManager<IdentityUser> AccountManager, SignInManager<IdentityUser> signInManager){
            _AccountManager = AccountManager;
            _signInManager = signInManager;
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
        public async Task<IActionResult> Register(string username, string password, string register_options, string voornaam, string tussenvoegsel, string achternaam){
            
            hulpverlener hulpverlener = new hulpverlener(voornaam, tussenvoegsel, achternaam, username, password, 2211);
            switch (register_options)
            {
                case "patiënt":
                currentAccount = new cliënt(voornaam, tussenvoegsel, achternaam, username, password, hulpverlener);
                break;
                case "ouder":
                currentAccount = new ouder(voornaam, tussenvoegsel, achternaam, username, password);
                break;
                case "hulpvelener":
                currentAccount = new hulpverlener(voornaam, tussenvoegsel, achternaam, username, password, 1235);
                break;
                case "moderator":
                currentAccount = new moderator(voornaam, tussenvoegsel, achternaam, username, password);
                break;
            }
            
            var user1 = new IdentityUser {UserName = username, Email = ""};

            var cereresult = await _AccountManager.CreateAsync(user1, password);

            if(cereresult.Succeeded){

                var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

                if(result.Succeeded){
                    return RedirectToAction("home");
                }
            }

             return RedirectToAction("register");
        }
     
        public IActionResult Register(){

             return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password){

            var user1 =  await _AccountManager.FindByNameAsync(username);

            if(user1 != null){
                Console.WriteLine("nice");
                var result = await _signInManager.PasswordSignInAsync(username, password, false, false);

                if(result.Succeeded){
                    return RedirectToAction("index");
                }
            }

            return RedirectToAction("login");
        }
         public IActionResult Login(){

         return View();
         }
        [HttpPost]
        public async Task<IActionResult> home(string username, string password, string voornaam, string tussenvoegsel, string achternaam){
            if(currentAccount.typAccount == "hulpvelener"){
                var serializedParent = JsonConvert.SerializeObject(currentAccount); 
                hulpverlener temp = JsonConvert.DeserializeObject<hulpverlener>(serializedParent);              
                new cliënt(voornaam, tussenvoegsel, achternaam, username, password, temp);
            }
            else{
                Console.WriteLine("je hebt niet de juiste machtiging");
            }
             return RedirectToAction("home");

        }
        [Authorize]
        public IActionResult home(){

         return View();
         }

        public async Task<IActionResult> logout(){
            await _signInManager.SignOutAsync();
            currentAccount = null;
             return RedirectToAction("index");
        }
    }
}
