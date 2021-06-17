using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Restaurants;
using OnlineDeliveryProject.Application.Queries.Restaurants;
using OnlineDeliveryProject.Application.Requests.Restaurants;
using OnlineDeliveryProject.Application.Searches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;
        public RestaurantController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }

        // GET: api/<RestaurantController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetRestaurantsQuery query, [FromQuery] RestaurantSearch search)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<RestaurantController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetRestaurantQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // POST api/<RestaurantController>
        [HttpPost]
        public IActionResult Post([FromForm] AddRestaurantRequest request, [FromServices] IAddRestaurantCommand command)
        {
            _executor.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<RestaurantController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm] UpdateRestaurantRequest request, [FromServices] IUpdateRestaurantCommand command)
        {
            request.Id = id;
            _executor.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<RestaurantController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteRestaurantCommand command)
        {
            _executor.ExecuteCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
