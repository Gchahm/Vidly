using System.Collections.Generic;
using Vidly.DAL;
using Vidly.Models;

namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            var membershipTypes = new List<MembershipType>
            {
                new MembershipType{Name = "Pay as you go", MembershipTypeId= MembershipType.PayAsYouGo, SignUpFee = 0, DurationInMonths = 0, DiscountRate = 0},
                new MembershipType{Name = "Monthly", MembershipTypeId= 2, SignUpFee = 30, DurationInMonths = 1, DiscountRate = 10},
                new MembershipType{Name = "Quarterly", MembershipTypeId= 3, SignUpFee = 90, DurationInMonths = 3, DiscountRate = 15},
                new MembershipType{Name = "Yearly", MembershipTypeId= 4, SignUpFee = 300, DurationInMonths = 12, DiscountRate = 20},
            };
            membershipTypes.ForEach(s => context.MembershipTypes.AddOrUpdate(s));
            context.SaveChanges();

            var customers = new List<Customer>
            {
                new Customer(){CustomerId= 1, Name = "Gustavo", MembershipTypeId = 2, BirthDate = DateTime.Parse("09/04/1992")},
                new Customer(){CustomerId= 2, Name = "Isabela", MembershipTypeId = 1}
            };
            customers.ForEach(c => context.Customers.AddOrUpdate(c));
            context.SaveChanges();

            var genres = new List<Genre>
            {
                new Genre() {GenreId = 1, Name = "Comedy"},
                new Genre() {GenreId = 2, Name = "Action"},
                new Genre() {GenreId = 3, Name = "Family"},
                new Genre() {GenreId = 4, Name = "Romance"},
            };
            genres.ForEach(g => context.Genres.AddOrUpdate(g));


            var movies = new List<Movie>
            {
                new Movie(){MovieId = 1, Name = "Hangover", ReleaseDate = DateTime.Today, DateAdded = DateTime.Today, NumberInStock = 5, GenreId = 1},
                new Movie(){MovieId = 2, Name = "Die Hard", ReleaseDate = DateTime.Today, DateAdded = DateTime.Today, NumberInStock = 5, GenreId = 2},
                new Movie(){MovieId = 3, Name = "The Terminator", ReleaseDate = DateTime.Today, DateAdded = DateTime.Today, NumberInStock = 5, GenreId = 2},
                new Movie(){MovieId = 4, Name = "Toy Story", ReleaseDate = DateTime.Today, DateAdded = DateTime.Today, NumberInStock = 5, GenreId = 3},
                new Movie(){MovieId = 5, Name = "Titanic", ReleaseDate = DateTime.Today, DateAdded = DateTime.Today, NumberInStock = 5, GenreId = 4},
            };
            movies.ForEach(m => context.Movies.AddOrUpdate(m));
            context.SaveChanges();


        }
    }
}
