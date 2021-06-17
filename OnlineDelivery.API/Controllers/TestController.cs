using Microsoft.AspNetCore.Mvc;
using OnlineDeliveryProject.DataAccess;
using OnlineDeliveryProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly OnlineDeliveryContext _context;

        public TestController(OnlineDeliveryContext context)
        {
            _context = context;
        }

        // POST api/<TestController>
        [HttpPost]
        public void Post()
        {
            var reviews = new List<Review>
            {
                new Review
                {
                    Customer = _context.Customers.Find(1),
                    Restaurant = _context.Restaurants.Find(9),
                    Description = "Top je!",
                    Rating = 5
                },
                new Review
                {
                    Customer = _context.Customers.Find(1),
                    Restaurant = _context.Restaurants.Find(10),
                    Description = "Onako",
                    Rating = 4
                },
                new Review
                {
                    Customer = _context.Customers.Find(4),
                    Restaurant = _context.Restaurants.Find(10),
                    Description = "Top je!",
                    Rating = 5
                },
                new Review
                {
                    Customer = _context.Customers.Find(6),
                    Restaurant = _context.Restaurants.Find(19),
                    Description = "Dobar restoran i hrana",
                    Rating = 5
                },
                new Review
                {
                    Customer = _context.Customers.Find(1),
                    Restaurant = _context.Restaurants.Find(16),
                    Description = "Lose",
                    Rating = 1
                },
                new Review
                {
                    Customer = _context.Customers.Find(4),
                    Restaurant = _context.Restaurants.Find(13),
                    Description = "Nista spec",
                    Rating = 3
                },
                new Review
                {
                    Customer = _context.Customers.Find(8),
                    Restaurant = _context.Restaurants.Find(15),
                    Description = "Top je!",
                    Rating = 5
                },
                new Review
                {
                    Customer = _context.Customers.Find(3),
                    Restaurant = _context.Restaurants.Find(12),
                    Description = "Top je!",
                    Rating = 4
                },
            };
            _context.Reviews.AddRange(reviews);
            _context.SaveChanges();
        }
    }
}
