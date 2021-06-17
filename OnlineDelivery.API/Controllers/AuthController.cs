﻿using OnlineDeliveryProject.Api.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineDeliveryProject.Application;
using OnlineDeliveryProject.Application.Commands.Customers;
using OnlineDeliveryProject.Application.Requests.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OnlineDelivery.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly JwtManager _manager;

        public AuthController(UseCaseExecutor executor, JwtManager manager)
        {
            _executor = executor;
            _manager = manager;
        }

        // POST api/<AuthController>
        [HttpPost]
        public IActionResult Post([FromForm] RegisterCustomerRequest request, [FromServices] IRegisterCustomerCommand command)
        {
            _executor.ExecuteCommand(command, request);
            return StatusCode(StatusCodes.Status201Created);
        }

        // POST api/Auth/login
        [HttpPost]
        [Route("login")]
        public IActionResult Post([FromForm] LoginRequest request)
        {
            var token = _manager.MakeToken(request);

            if(token == null)
            {
                return Unauthorized();
            }

            return Ok(new { token });
        }
    }
}
