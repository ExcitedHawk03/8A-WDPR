using System;
using Xunit;
using Moq;
using WebApplicatie.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using WebApplicatie.Hubs;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using WebApplicatie.Models;

namespace WebApplicatie.Tests
{
    public class ChatTests
    {
        public readonly ClientContext _context;
        
        [Fact]
        public void Find_JuisteTypeView()
        {
            //Arrange
            var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
            var IHubContextMock = new Mock<IHubContext<chatHub>>();
            
            //Hier wordt er een InMemory Database gerealiseerd
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            ChatController controller = new ChatController(userManagerMock.Object, context, IHubContextMock.Object);

            //Act
            var result = controller.Find();

            //Assert
            Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void moderatorChatSelection_Test ()
        {
            //Arrange
            var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
            var IHubContextMock = new Mock<IHubContext<chatHub>>();
            
            //Hier wordt er een InMemory Database gerealiseerd
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            ChatController controller = new ChatController(userManagerMock.Object, context, IHubContextMock.Object);

            //Act
            var result = controller.moderatorChatSelection();

            //Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void ChatSelection_Test ()
        {
            //Arrange
            
            var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
            var IHubContextMock = new Mock<IHubContext<chatHub>>();
            
            //Hier wordt er een InMemory Database gerealiseerd
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            Chat chat = new Chat() {Id = 1, naam = "testruimte", ageGroup = 13};
            context.chat.Add(chat);
            context.SaveChanges();

            ChatController controller = new ChatController(userManagerMock.Object, context, IHubContextMock.Object);

            //Act
            var result = controller.chatSelection(13, "testruimte");

            //Assert
            Assert.Equal(context.chat.First().ageGroup, 13);
            Assert.Equal(context.chat.First().naam, "testruimte");
        }

        [Fact]

        public void CreateMessage_JuisteTypeView()
        {
             //Arrange
            var userManagerMock = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
            var IHubContextMock = new Mock<IHubContext<chatHub>>();
            
            //Hier wordt er een InMemory Database gerealiseerd
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            ChatController controller = new ChatController(userManagerMock.Object, context, IHubContextMock.Object);

            //Act
            var result = controller.CreateMessage(1, null);

            //Assert
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }
    }
}
