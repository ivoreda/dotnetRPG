using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetRPG.Data;
using dotnetRPG.Dtos.User;
using dotnetRPG.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotnetRPG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Authcontroller : ControllerBase
    {
        private readonly IAuthRepository _authRepo;
        public Authcontroller(IAuthRepository authRepo)
        {
            _authRepo = authRepo;
        }

        [HttpPost("Register")]
        public async Task<ActionResult<ServiceResponse<int>>> Register(UserRegisterDto request)
        {
            var response = await _authRepo.Register(
                new User { Username = request.Username }, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<ServiceResponse<string>>> Login(UserLoginDto request)
        {
            var response = await _authRepo.Login(
                request.Username, request.Password
            );
            if (!response.Success)
            {
                return BadRequest(response);
            }
            else
            {
                return Ok(response);
            }
        }
    }


}