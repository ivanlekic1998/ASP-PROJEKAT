using OnlineDeliveryProject.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Cities;
using OnlineDeliveryProject.Application.Requests.Cities;
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
    public class CityController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public CityController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<CityController>
        [HttpGet]
        public IActionResult Get([FromQuery] CitiesSearch search, [FromServices] IGetCitiesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<CityController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCityRequest request, [FromServices] IAddCityCommand command)
        {
            _executor.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<CityController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCityCommand command)
        {
            _executor.ExecuteCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
