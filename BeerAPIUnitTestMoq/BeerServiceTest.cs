using Beer.Interfaces;
using Beer.Models;
using Beer.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace BeerAPIUnitTestMoq
{
    public class BeerServiceTest
    {


        [Fact]
        public void GetAllBeers_Test()
        {
            //Arrange
            var service = new Mock<IBeer>();
            var beers = GetMockBeerData();
            service.Setup(x => x.GetAllBeers()).Returns(beers);
            var controller = new BeerCollection.Controllers.Beer(service.Object);
            //Act
            var results = controller.GetAllBeers();
            var count = results.Result.Count;
            //Assert
            Assert.Equal(count, 4);
        }

        private async Task<List<BeerViewModel>> GetMockBeerData()
        {
            List<BeerViewModel> beer = new List<BeerViewModel>();
            beer.Add(new BeerViewModel { BeerName = "Three Floyds Zombie Dust", BeerType = "Pale Ale", Ratings = 5 });
            beer.Add(new BeerViewModel { BeerName = "Sierra Nevada Pale Ale", BeerType = "Pale Ale", Ratings = 5 });
            beer.Add(new BeerViewModel { BeerName = "DRY IRISH STOUT ", BeerType = "Stout", Ratings = 5 });
            beer.Add(new BeerViewModel { BeerName = "MILK STOUT", BeerType = "Stout", Ratings = 5 });
            return beer;
        }
    }
}
