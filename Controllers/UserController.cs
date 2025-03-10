﻿using AutoMapper;
using GymApp.Models.Api.User;
using GymApp.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymApp.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService UserService { get; set; }
        private IMapper Mapper { get; }

        public UserController(IUserService userService, IMapper mapper)
        {
            UserService = userService;
            Mapper = mapper;
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Login([FromBody] UserLoginModel model)
        {
            if (UserService.UserExists(model.Username))
                return Ok();
            else
                return NotFound();
        }

        [HttpPost("register")]
        public ActionResult Register([FromBody] UserFormModel model)
        {
            model.Username = model.Username.ToLower();

            if (UserService.UserExists(model.Username))
                return BadRequest("Użytkownik o takiej nazwie już istnieje.");

            UserService.Create(model, model.Password);

            return StatusCode(201);
        }

        [HttpGet("{id}")]
        public ActionResult<UserViewModel> Fetch(int id)
        {
            var user = UserService.Fetch(id);

            if (user == null)
                return NotFound();

            return Mapper.Map<UserViewModel>(user);
        }
        

        [HttpPost("{id}")]
        public ActionResult Update(int id, [FromBody] UserFormModel model)
        {
            var user = UserService.Fetch(id);

            if (user == null)
                return NotFound();

            UserService.Update(model, user);

            return Ok();
        }
       
        
    }
}
