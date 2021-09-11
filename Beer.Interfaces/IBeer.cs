using Beer.Models;
using Beer.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Beer.Interfaces
{
    public interface IBeer
    {
        // Fetching All Beers
        Task<List<BeerViewModel>> GetAllBeers();
        // Adding Beer        
        Task AddBeer(BeerModel _beer);
        // Search Filter By Name
        Task<List<BeerViewModel>> FilterBeersByName(string _filter);
        Task AddRatings(int beerId, int ratings);
    }
}
