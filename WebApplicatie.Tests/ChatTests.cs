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
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace WebApplicatie.Tests
{
    public class ChatTests
    {
        private readonly Mock<UserManager<Account>> _AccountManager;
        private readonly Mock<IHubContext<chatHub>> _IHubContext;

        private readonly ClientContext _context;
        private readonly Mock<ClientContext> _contextMock;


        public ChatTests(){
            _AccountManager = new Mock<UserManager<Account>>(Mock.Of<IUserStore<Account>>(), null, null, null, null, null, null, null, null);
            _IHubContext = new Mock<IHubContext<chatHub>>();

            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            _context = new ClientContext(options);
            _contextMock = new Mock<ClientContext>(options);
        }
        
        [Fact]
        public void Find_JuisteTypeView()
        {
            //Arrange

            ChatController controller = new ChatController(_AccountManager.Object, _context, _IHubContext.Object);

            //Act
            var result = controller.Find();

            //Assert
            Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void moderatorChatSelection_Test ()
        {
            //Arrange
            ChatController controller = new ChatController(_AccountManager.Object, _context, _IHubContext.Object);

            //Act
            var result = controller.moderatorChatSelection();

            //Assert
            Assert.IsType<ViewResult>(result);
        }


        [Fact]

        public void CreateMessage_JuisteTypeView()
        {
             //Arrange
            ChatController controller = new ChatController(_AccountManager.Object, _context, _IHubContext.Object);

            //Act
            var result = controller.CreateMessage(1, null);

            //Assert
            var viewResult = Assert.IsType<Task<IActionResult>>(result);
        }
        [Fact]
        public async Task CreateMessage_messageAdd_1KeerAsync(){

            Mock<DbSet<Message>> MessageMock = new Mock<DbSet<Message>>();
            _contextMock.Setup(c => c.message).Returns(MessageMock.Object); 
            ChatController controller = new ChatController(_AccountManager.Object, _contextMock.Object, _IHubContext.Object);

            //Act
            await controller.CreateMessage(It.IsAny<int>(), It.IsAny<string>());

            _contextMock.Verify(c => c.message.Add(It.IsAny<Message>()), Times.Once());
        }

        [Fact]
        public async Task chatSelection_Add_1KeerAanroepenAsync()
        {
            // Given
            Mock<DbSet<Chat>> chatMock = new Mock<DbSet<Chat>>();
            Mock<DbSet<ChatUser>> chatUserMock = new Mock<DbSet<ChatUser>>();
            _contextMock.Setup(c => c.chat).Returns(chatMock.Object);
            _contextMock.Setup(c => c.chatUsers).Returns(chatUserMock.Object);
            ChatController c = new ChatController(_AccountManager.Object, _contextMock.Object, _IHubContext.Object);
        
            // When
            await c.chatSelection(It.IsAny<int>(), It.IsAny<string>());
        
            // Then
            _contextMock.Verify(c => c.chat.Add(It.IsAny<Chat>()), Times.Once());
            

        }
    }
}
