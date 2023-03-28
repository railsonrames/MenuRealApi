using MenuRealApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuRealApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaturantController : ControllerBase
    {
        private static Dictionary<System.DayOfWeek, string> workHours = new()
        {
            { System.DayOfWeek.Monday, "11:30 ~ 14:30|19:30 ~ 21:30" },
            { System.DayOfWeek.Tuesday, "Fechado" },
            { System.DayOfWeek.Wednesday, "11:30 ~ 14:30|19:30 ~ 21:30" },
            { System.DayOfWeek.Thursday, "Fechado" },
            { System.DayOfWeek.Friday, "11:30 ~ 14:30|19:30 ~ 21:30" },
            { System.DayOfWeek.Saturday, "11:30 ~ 14:30|19:30 ~ 21:30" },
            { System.DayOfWeek.Sunday, "11:30 ~ 14:30|19:30 ~ 21:30" },
        };

        private static List<Restaurant> restaurantList = new()
        {
            new Restaurant
            {
                Id = System.Guid.NewGuid(),
                Name = "Casa das Sandes",
                Buffet = false,
                Category = new Category { Id = 1, Name = "Portuguesa", IsActive = true, Order = 1 },
                PriceStar = 2,
                Description = "Diárias, sandes e bifanas.",
                TakeAway = true,
                Address = new Address { Id = System.Guid.NewGuid(), City = "Ponte de Sor", Number = "63", Country = Country.Portugal, PostalCode = "7400-145", Street = "Avenida da Liberdade" },
                CreatedAt = System.DateTime.Now,
                WorkHours = workHours
            },
            new Restaurant
            {
                Id = System.Guid.NewGuid(),
                Name = "Petisqueira Alentejana",
                Buffet = false,
                Category = new Category { Id = 1, Name = "Portuguesa", IsActive = true, Order = 2 },
                PriceStar = 4,
                Description = "Diárias, sandes e petiscos.",
                TakeAway = true,
                Address = new Address { Id = System.Guid.NewGuid(), City = "Ponte de Sor", Number = "12", Country = Country.Portugal, PostalCode = "7400-145", Street = "Rua Luiz de Camões" },
                CreatedAt = System.DateTime.Now,
                WorkHours = workHours
            },
        };

        // GET: api/<RestaturantController>
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> Get()
        {
            return Ok(restaurantList);
        }

        // GET api/<RestaturantController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> Get(System.Guid id)
        {
            var restaurant = restaurantList.Find(x => x.Id == id);
            if (restaurant is null)
                return NotFound();
            else
                return Ok(restaurant);
        }

        // POST api/<RestaturantController>
        [HttpPost]
        public async Task<ActionResult<List<Restaurant>>> Post([FromBody] Restaurant request)
        {
            if (ModelState.IsValid)
            {
                restaurantList.Add(request);
                return Ok(restaurantList);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<RestaturantController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Restaurant>> Put(System.Guid id, [FromBody] Restaurant request)
        {
            if (ModelState.IsValid)
            {
                var restaurant = restaurantList.Find(x => x.Id == id);
                if (restaurant is null)
                {
                    return NotFound();
                }

                restaurant.Name = request.Name;
                restaurant.PriceStar = request.PriceStar;
                restaurant.Address = request.Address;
                restaurant.Buffet = request.Buffet;
                restaurant.Category = request.Category;
                restaurant.Description = request.Description;
                restaurant.UpdatedAt = request.UpdatedAt;
                restaurant.TakeAway = request.TakeAway;
                restaurant.WorkHours = request.WorkHours;

                return Ok(restaurantList);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<RestaturantController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Restaurant>>> Delete(System.Guid id)
        {
            var restaurant = restaurantList.Find(x => x.Id == id);
            if (restaurant is null)
            {
                return NotFound();
            }
            else
            {
                restaurantList.Remove(restaurant);
                return Ok(restaurantList);
            }
        }
    }
}
