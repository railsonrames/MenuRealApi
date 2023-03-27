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
        // GET: api/<RestaturantController>
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> Get()
        {
            var workHours = new Dictionary<System.DayOfWeek, string>()
                    {
                        { System.DayOfWeek.Monday , "11:30 ~ 14:30|19:30 ~ 21:30" },
                        { System.DayOfWeek.Tuesday, "Fechado"},
                        { System.DayOfWeek.Wednesday , "11:30 ~ 14:30|19:30 ~ 21:30" },
                        { System.DayOfWeek.Thursday , "Fechado" },
                        { System.DayOfWeek.Friday , "11:30 ~ 14:30|19:30 ~ 21:30" },
                        { System.DayOfWeek.Saturday , "11:30 ~ 14:30|19:30 ~ 21:30" },
                        { System.DayOfWeek.Sunday , "11:30 ~ 14:30|19:30 ~ 21:30" },
                    };

            var restaurantList = new List<Restaurant>
            {
                new Restaurant
                {
                    Id = System.Guid.NewGuid(),
                    Name = "Casa das Sandes",
                    Buffet = false,
                    Category = new Category { Id = 1, Name = "Portuguesa", IsActive = true, Order = 1},
                    PriceStar = 2,
                    Description = "Diárias, sandes e bifanas.",
                    TakeAway = true,
                    Address = new Address { Id = System.Guid.NewGuid(), City = "Ponte de Sor", Number = "63", Country = Country.Portugal, PostalCode = "7400-145", Street = "Avenida da Liberdade"},
                    CreatedAt = System.DateTime.Now,
                    WorkHours = workHours
                }
            };

            return Ok(restaurantList);
        }

        // GET api/<RestaturantController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RestaturantController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RestaturantController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RestaturantController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
