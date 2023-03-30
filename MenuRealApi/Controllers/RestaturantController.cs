using MenuRealApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using MenuRealApi.Services.RestaurantService;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MenuRealApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaturantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        public RestaturantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // GET: api/<RestaturantController>
        [HttpGet]
        public async Task<ActionResult<List<Restaurant>>> GetAll()
        {
            var restaurantList = _restaurantService.GetAll();
            return Ok(restaurantList);
        }

        // GET api/<RestaturantController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Restaurant>> Get(Guid id)
        {
            var restaurant = _restaurantService.Get(id);
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
                var restaurantList = _restaurantService.Create(request);
                return Ok(restaurantList);
            }
            else
            {
                return BadRequest();
            }
        }

        // PUT api/<RestaturantController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Restaurant>> Put(Guid id, [FromBody] Restaurant request)
        {
            if (ModelState.IsValid)
            {
                var restaurant = _restaurantService.Update(id, request);
                return Ok(restaurant);
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<RestaturantController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Restaurant>>> Delete(Guid id)
        {
            var restaurantList = _restaurantService.Delete(id);
            if (restaurantList is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(restaurantList);
            }
        }
    }
}
