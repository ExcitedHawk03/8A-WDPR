using System;
using Xunit;
using Moq;
using WebApplicatie.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WebApplicatie.Tests
{
    public class HomeTests1
    {

        // [Fact]
        // public void Index_JuisteTypeView()
        // {
        //     //Arrange

        //     //Hieronder worden mocks gemaakt van usermanager en signinmanager
        //     var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
        //     var signInManagerMock = new Mock<SignInManager<Account>>(userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), 
        //     Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);

        //     //Hier wordt er een InMemory Database gerealiseerd
        //     DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
        //     ClientContext context = new ClientContext(options);

        //     HomeController controller = new HomeController(userManagerMock.Object, signInManagerMock.Object, context);


        //     //Act
        //     var result = controller.Index();
            
        //     //Assert (Testen of het type een view is)
        //     var viewResult = Assert.IsType<ViewResult>(result);
            
        // }

        // [Fact]
        // public void LogIn_JuisteTypeView()
        // {
        //     //Arrange

        //     //Hieronder worden mocks gemaakt van usermanager en signinmanager
        //     var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
        //     var signInManagerMock = new Mock<SignInManager<Account>>(userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), 
        //     Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);

        //     //Hier wordt er een InMemory Database gerealiseerd
        //     DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
        //     ClientContext context = new ClientContext(options);
            
        //     HomeController controller = new HomeController(userManagerMock.Object, signInManagerMock.Object,context);

        //     //Act
        //     var result = controller.Login();
            
        //     //Assert (Testen of het type een view is)
        //     var viewResult = Assert.IsType<ViewResult>(result);
            
        // }

        // [Fact]
        // public void Logout_RedirectActionTest()
        // {
        //     //Arrange

        //     //Hieronder worden mocks gemaakt van usermanager en signinmanager
        //     var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
        //     var signInManagerMock = new Mock<SignInManager<Account>>(userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), 
        //     Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);

        //     //Hier wordt er een InMemory Database gerealiseerd
        //     DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
        //     ClientContext context = new ClientContext(options);
            
        //     HomeController controller = new HomeController(userManagerMock.Object, signInManagerMock.Object,context);

        //     //Act
        //     var result =  controller.logout();
        //     var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
           

        //     //assert
        //     Assert.Equal("Home", redirectToActionResult.ControllerName);
        //     Assert.Equal("Index", redirectToActionResult.ActionName);
            
        // }


        // [Fact]
        // public void Orthopedagogen_JuisteTypeView()
        // {
        //     //Arrange

        //     //Hieronder worden mocks gemaakt van usermanager en signinmanager
        //     var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
        //     var signInManagerMock = new Mock<SignInManager<Account>>(userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), 
        //     Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);


        //     //Hier wordt er een InMemory Database gerealiseerd
        //     DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
        //     ClientContext context = new ClientContext(options);

        //     HomeController controller = new HomeController(userManagerMock.Object, signInManagerMock.Object,context);

        //     //Act
        //     var result = controller.Orthopedagogen();
            
        //     //Assert (Testen of het type een view is)
        //     var viewResult = Assert.IsType<ViewResult>(result);
            
        // }

        // [Fact]
        // public void AanmeldingIntake_JuisteTypeView()
        // {
        //     //Arrange

        //     //Hieronder worden mocks gemaakt van usermanager en signinmanager
        //     var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
        //     var signInManagerMock = new Mock<SignInManager<Account>>(userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), 
        //     Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);

        //     //Hier wordt er een InMemory Database gerealiseerd
        //     DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
        //     ClientContext context = new ClientContext(options);

        //     HomeController controller = new HomeController(userManagerMock.Object, signInManagerMock.Object,context);

        //     //Act
        //     var result = controller.AanmeldingIntake();
            
        //     //Assert (Testen of het type een view is)
        //     var viewResult = Assert.IsType<ViewResult>(result);
            
        // }

        // [Fact]
        // public void Contact_JuisteTypeView()
        // {
        //     //Arrange

        //     //Hieronder worden mocks gemaakt van usermanager en signinmanager
        //     var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
        //     var signInManagerMock = new Mock<SignInManager<Account>>(userManagerMock.Object, Mock.Of<IHttpContextAccessor>(), 
        //     Mock.Of<IUserClaimsPrincipalFactory<Account>>(), null, null, null, null);

        //     //Hier wordt er een InMemory Database gerealiseerd
        //     DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
        //     ClientContext context = new ClientContext(options);
            
        //     HomeController controller = new HomeController(userManagerMock.Object, signInManagerMock.Object, context);

        //     //Act
        //     var result = controller.Contact();

        //     //Assert (Testen of het type een view is)
        //     Assert.IsType<ViewResult>(result);
        // }
    }
}