using System;
using Xunit;
using Moq;
using WebApplicatie.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplicatie.Tests
{
    public class HomeTests
    {
        private readonly Mock<UserManager<Account>> _AccountManager;
        private readonly Mock<SignInManager<Account>> _signInManager;

        private readonly ClientContext _context;

        public HomeTests(){
            _AccountManager = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
            _signInManager = new Mock<SignInManager<Account>>(_AccountManager.Object, Mock.Of<IHttpContextAccessor>(), 
            Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);

            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            _context = new ClientContext(options);
        }

        [Fact]
        public void Index_JuisteTypeView()
        {
            //Arrange

            //Hieronder worden mocks gemaakt van usermanager en signinmanager
            var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
            var signInManagerMock = new Mock<SignInManager<Account>>(userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), 
            Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);

            //Hier wordt er een InMemory Database gerealiseerd
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            HomeController controller = new HomeController(userManagerMock.Object, signInManagerMock.Object, context);


            //Act
            var result = controller.Index();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void LogIn_JuisteTypeView()
        {
            //Arrange

            //Hieronder worden mocks gemaakt van usermanager en signinmanager
            var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
            var signInManagerMock = new Mock<SignInManager<Account>>(userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), 
            Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);

            //Hier wordt er een InMemory Database gerealiseerd
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);
            
            HomeController controller = new HomeController(userManagerMock.Object, signInManagerMock.Object,context);

            //Act
            var result = controller.Login();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void Orthopedagogen_JuisteTypeView()
        {
            //Arrange

            //Hieronder worden mocks gemaakt van usermanager en signinmanager
            var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
            var signInManagerMock = new Mock<SignInManager<Account>>(userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), 
            Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);


            //Hier wordt er een InMemory Database gerealiseerd
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            HomeController controller = new HomeController(userManagerMock.Object, signInManagerMock.Object,context);

            //Act
            var result = controller.Orthopedagogen();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void AanmeldingIntake_JuisteTypeView()
        {
            //Arrange

            //Hieronder worden mocks gemaakt van usermanager en signinmanager
            var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
            var signInManagerMock = new Mock<SignInManager<Account>>(userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), 
            Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);

            //Hier wordt er een InMemory Database gerealiseerd
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            HomeController controller = new HomeController(userManagerMock.Object, signInManagerMock.Object,context);

            //Act
            var result = controller.AanmeldingIntake();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void Contact_JuisteTypeView()
        {
            //Arrange

            //Hieronder worden mocks gemaakt van usermanager en signinmanager
            
            HomeController controller = new HomeController(_AccountManager.Object, _signInManager.Object, _context);

            //Act
            var result = controller.Contact();

            //Assert (Testen of het type een view is)
            Assert.IsType<ViewResult>(result);
        }
        [Fact]
        public async void Register_CreateAsync_eenKeer()
        {
                _AccountManager.Setup(u => u.CreateAsync(It.IsAny<Account>(), It.IsAny<string>()));          

                HomeController h = new HomeController(_AccountManager.Object, _signInManager.Object, _context);
                var result = Assert.IsType<RedirectToActionResult>(await h.Register("bob", "van", "jap", 12, "M", "test@test", "12345", "1234DA", "leiden", "asdf", "123A", null, null, null));
                 
                _AccountManager.Verify(u => u.CreateAsync(It.IsAny<Account>(), It.IsAny<string>()), Times.Once());
        }
    }
}