using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Customers;
using OnlineDeliveryProject.Application.Queries.Customers;
using OnlineDeliveryProject.Application.Requests.Customers;
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
    public class CustomerController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;

        public CustomerController(IApplicationActor actor, UseCaseExecutor executor)
        {
            _actor = actor;
            _executor = executor;
        }

        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get([FromServices] IGetCustomersQuery query, [FromQuery] CustomerSearch search)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id, [FromServices] IGetOneCustomerFrontQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, id));
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put([FromForm] UpdateCustomerRequest request, [FromServices] IUpdateCustomerCommand command, int id)
        {
            request.Id = id;

            _executor.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteCustomerCommand command)
        {
            _executor.ExecuteCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
