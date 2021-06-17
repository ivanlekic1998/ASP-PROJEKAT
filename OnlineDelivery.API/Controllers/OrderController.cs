using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Orders;
using OnlineDeliveryProject.Application.Requests.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public OrderController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // POST api/<OrderController>
        [HttpPost]
        public IActionResult Post([FromBody] AddOrderRequest request, [FromServices] IAddOrderCommand command)
        {
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateOrderRequest request, [FromServices] IUpdateOrderCommand command)
        {
            request.Id = id;

            _executor.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status204NoContent);
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteOrderCommand command)
        {
            _executor.ExecuteCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
