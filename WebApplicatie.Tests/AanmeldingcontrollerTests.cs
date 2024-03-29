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
            hulpverlener h = new hulpverlener{Tussenvoegsel = null, Achternaam = "James", Leeftijd = DateTime.Now, Geslacht = "M",
             Telnr = "0687456321", Adres = "adres 11", Postcode = "1234AF", Plaats = "Rotterdam", Voornaam = "Mark", typAccount = "hulpverlener" };
            Aanmelding aa = new Aanmelding {VoorNaam = "Bill", AchterNaam = "Pieter", Datum = DateTime.Now, Hulpverlener = "Mark"};

              DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
            ClientContext context = new ClientContext(options);
            
            context.Aanmelding.Add(aa);
            context.SaveChanges();

            Assert.Equal("Mark", aa.Hulpverlener);
            Assert.Equal(1, context.Aanmelding.Count());
        }
    

     [Fact]
        public async void Create_1Keer()
        {       
         
        //Arrange
        DbContextOptions options = new DbContextOptionsBuilder().UseInMemoryDatabase("ClientContext").Options;
        var mockContext = new Mock<ClientContext>(options);
        
        // //Act
         var result = new AanmeldingController(mockContext.Object);
         result.Create("Jan", "Jaap", DateTime.Now, "Takezo");
     
        //Assert
            mockContext.Verify(m => m.Add(It.IsAny<Aanmelding>()), Times.Once());
        }
    }



