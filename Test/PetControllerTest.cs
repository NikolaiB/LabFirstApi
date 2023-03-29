using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication10.Controllers;
using WebApplication12.NewFolder;

namespace Test
{   [TestClass]
    internal class PetControllerTest
    {
        [TestMethod]

        public void Get_PositiveTesting_ShouldComlrteSuccessfully()
        {
            var petServicemoq = new Mock<IPetService>();

            var petController = new PetsController(petServicemoq.Object);

            var res = petController.Get();

            Assert.IsNotNull(res); 
        }
    }
}
