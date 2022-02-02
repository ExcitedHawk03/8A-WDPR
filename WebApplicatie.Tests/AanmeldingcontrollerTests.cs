using System;
using Xunit;
using Moq;
using WebApplicatie.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class AanmeldingTests
    {

        [Fact]
        public void Create_JuisteTypeViewReturnen()
        {
            //Arrange
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            AanmeldingController controller = new AanmeldingController(context);

            //Act
            var result = controller.Create();

            //Assert
            var ViewResult = Assert.IsType<ViewResult>(result);
        }

        // public void Create_RedirectToActionTesten_Gelukt()
        // {
        //     //Arrange
        //     Aanmelding aanmelding = new Aanmelding();
        //     DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
        //     ClientContext context = new ClientContext(options);

        //     AanmeldingController controller = new AanmeldingController(context);

        //     //Act
        //     var result = controller.Create(aanmelding);
        //     var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

        //     //assert
        //     Assert.Equal("Aanmelding", redirectToActionResult.ControllerName);
        //     Assert.Equal("Gelukt", redirectToActionResult.ActionName);


        // }

        // [Fact]
        // public void Edit_RedirectToActionTesten_Aanpassen()
        // {
        //     //Arrange
        //     Aanmelding aanmelding = new Aanmelding();
        //     DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
        //     ClientContext context = new ClientContext(options);

        //     AanmeldingController controller = new AanmeldingController(context);

        //     //Act
        //     var result = controller.Edit(It.IsAny<int>(), aanmelding);
        //     var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

        //     //assert
        //     Assert.Equal("Aanmelding", redirectToActionResult.ControllerName);
        //     Assert.Equal("Aanpassen", redirectToActionResult.ActionName);

        // }

        //  [Fact]
        // public void DeleteConfirmed_RedirectToActionTesten_Afkeuren()
        // {
        //     //Arrange
        //     Aanmelding aanmelding = new Aanmelding();
        //     DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
        //     ClientContext context = new ClientContext(options);

        //     AanmeldingController controller = new AanmeldingController(context);

        //     //Act
        //     var result = controller.DeleteConfirmed(It.IsAny<int>());
        //     var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

        //     //assert
        //     Assert.Equal("Aanmelding", redirectToActionResult.ControllerName);
        //     Assert.Equal("Afkeuren", redirectToActionResult.ActionName);

        // }

        [Fact]
        public void Gelukt_ResultMoetEenTypeZijn()
        {
            //Arrange
             DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            AanmeldingController controller = new AanmeldingController(context);

            //Act
            var result = controller.Gelukt();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void Aanpassen_ResultMoetEenTypeZijn()
        {
            //Arrange
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            AanmeldingController controller = new AanmeldingController(context);

            //Act
            var result = controller.Aanpassen();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
            
        }

        [Fact]
        public void Afkeuren_ResultMoetEenTypeZijn()
        {
            //Arrange
            DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);

            AanmeldingController controller = new AanmeldingController(context);

            //Act
            var result = controller.Afkeuren();
            
            //Assert (Testen of het type een view is)
            var viewResult = Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void TestData()
        {
            hulpverlener h = new hulpverlener{Tussenvoegsel = null, Achternaam = "James", Leeftijd = 25, Geslacht = "M",
             Telnr = "0687456321", Adres = "adres 11", Postcode = "1234AF", Plaats = "Rotterdam", Voornaam = "Mark", typAccount = "hulpverlener" };
            Aanmelding aa = new Aanmelding {VoorNaam = "Bill", AchterNaam = "Pieter", Datum = DateTime.Now, Hulpverlener = "Mark"};

              DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);
            
            context.Aanmelding.Add(aa);
            context.SaveChanges();

            Assert.Equal("Mark", aa.Hulpverlener);
            Assert.Equal(1, context.Aanmelding.Count());
        }
    }
