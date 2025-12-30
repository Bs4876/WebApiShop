using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entities;
using Services;
using NLog.Web;
using DTOs;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WepApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
    IUsersServices _usersServices;
    private readonly ILogger<UsersController> _logger;
    public UsersController(IUsersServices iUsersServices, ILogger<UsersController> logger)
    {
            _usersServices = iUsersServices;
            _logger = logger;
    }
       
        // GET api/<Users>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<UserDTO>> Get(int ind)
        {
            UserDTO user =await _usersServices.getUserById(ind);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        [HttpPost]
        // POST api/<Users>
        public async Task<ActionResult<UserDTO>> POST([FromBody] UserToRegisterDTO user)
        {
            UserDTO postUser =await _usersServices.registerUser(user);
            if (postUser == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = postUser.UserId }, postUser);
        }

        [HttpPost ("login")]
       public async Task<ActionResult<UserDTO>> Post([FromBody] UserLog userToLog)
       {
            UserDTO user  =await _usersServices.loginUser(userToLog);
           
            if (user == null)
            {
                _logger.LogInformation("user not exist");
                return NoContent();
            }
            _logger.LogInformation("User login successfully: Name: {FullName}, Email: {Email}", $"{user.FirstName} {user.LastName}", user.UserMail);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserToRegisterDTO userToUpdate)
        {
            UserDTO postUser =await _usersServices.updateUser(userToUpdate,id);
            if (postUser == null)
                return BadRequest("Password is not strong enough");
            return NoContent();
        }

    }
}
