using OnlineDeliveryProject.Application.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Categories;
using OnlineDeliveryProject.Application.Requests.Categories;
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
    public class CategoryController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        public CategoryController(UseCaseExecutor executor)
        {
            _executor = executor;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult Get([FromQuery] CategoriesSearch search, [FromServices] IGetCategoriesQuery query)
        {
            return Ok(_executor.ExecuteQuery(query, search));
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post([FromBody] AddCategoryRequest request, [FromServices] IAddCategoryCommand command)
        {
            _executor.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status201Created);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateCategoryRequest request, [FromServices] IUpdateCategoryCommand command)
        {
            request.Id = id;

            _executor.ExecuteCommand(command, request);

            return StatusCode(StatusCodes.Status204NoContent);
        }
    }
}
