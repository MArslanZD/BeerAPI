using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beer.Interfaces;
using Beer.Models;
using Beer.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

    /// <summary>
    /// Beer Web Service
    /// Exelia Tech Test
    /// Created by: Arslan Zahid
    /// </summary>
namespace BeerCollection.Controllers
{
    [Produces("application/json")]
    [Route("api/beers")]
    [ApiController()]
    public class Beer : ControllerBase
    {
        private readonly IBeer _beers;

        public Beer(IBeer beers) => _beers = beers;

        // Listing of All Beers
        [Route("fetch_beers")]
        [HttpGet]
        public async Task<List<BeerViewModel>> GetAllBeers() => await _beers.GetAllBeers();
       
        // Searching by Name all the Beers
        [Route("fetch_beers_by_name")]
        [HttpGet]
        public async Task<List<BeerViewModel>> FilterBeersByName(string _beerName) => await _beers.FilterBeersByName(_beerName);

        // Adding Review and then Averaging the overall Review .
        [Route("add_review")]
        [HttpPut]
        public async Task<IActionResult> AddReview(int beerId, int ratings)
        {
            try
            {
                string resultMessage = string.Empty;
                if (ratings >= 1 && ratings <= 5)
                {
                    await _beers.AddRatings(beerId, ratings);
                    resultMessage = "Review Added";
                }
                else
                    resultMessage = "Please Enter review between 1 to 5...";

                return StatusCode(200, new JsonResult(new { status = resultMessage }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        // Adding New Beers
        [Route("add_beer")]
        [HttpPost]
        public async Task<IActionResult> AddBeer([FromBody] BeerModel _addBeer)
        {
            try
            {
                await _beers.AddBeer(_addBeer);
                return new JsonResult(new { status = "Beer Entry Saved" });
            }
            catch (Exception ex)
            {

                return StatusCode(500, ex.Message);
            }
        }


    }
}
