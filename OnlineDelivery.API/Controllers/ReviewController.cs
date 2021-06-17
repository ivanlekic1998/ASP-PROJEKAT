using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Reviews;
using OnlineDeliveryProject.Application.Requests.Reviews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public ReviewController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // POST api/<ReviewController>
        [HttpPost]
        public IActionResult Post([FromBody] AddReviewRequest request, [FromServices] IAddReviewCommand command)
        {
            _executor.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id, [FromServices] IDeleteReviewCommand command)
        {
            _executor.ExecuteCommand(command, id);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
