using System;
using Xunit;
using Moq;
using WebApplicatie.Controllers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using WebApplicatie.Hubs;
using Microsoft.AspNetCore.Mvc;

namespace WebApplicatie.Tests
{
    public class OrthopedagoogTest
    {   
        [Fact]
        public void OrthopedagoogController_MethodeJan_ResultMoetEenTypeZijn()
        {
            //Arrange
            OrthopedagoogController controller = new OrthopedagoogController();

            //Act
            var result = controller.Jan();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void OrthopedagoogController_MethodeLaura_ResultMoetEenTypeZijn()
        {
            //Arrange
            OrthopedagoogController controller = new OrthopedagoogController();

            //Act
            var result = controller.Laura();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void OrthopedagoogController_MethodeTakezo_ResultMoetEenTypeZijn()
        {
            //Arrange
            OrthopedagoogController controller = new OrthopedagoogController();

            //Act
            var result = controller.Takezo();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void OrthopedagoogController_MethodeDagmar_ResultMoetEenTypeZijn()
        {
            //Arrange
            OrthopedagoogController controller = new OrthopedagoogController();

            //Act
            var result = controller.Dagmar();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }
    }
}