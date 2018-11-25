using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DAL;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
            _context.Configuration.ProxyCreationEnabled = false;
        }
        [HttpPost]
        public IHttpActionResult CreateRentals(RentalDto rentalDto)
        {
            if (rentalDto.MovieIds.Count == 0)
                return BadRequest("The list of movies is empty");

            var customer = _context.Customers.SingleOrDefault(c => c.CustomerId == rentalDto.CustomerId);

            if (customer == null)
                return BadRequest("Customer id is invalid " + rentalDto.CustomerId);

            var movies = _context.Movies.Where(m => rentalDto.MovieIds.Contains(m.MovieId)).ToList();

            if (movies.Count != rentalDto.MovieIds.Count)
                return BadRequest("One or more movies could not be found");

            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest(movie.Name + " is not available");

                movie.NumberAvailable --;

                var rental = new Rental()
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now

                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
