using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Entities;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WepApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
       IUsersServices _usersServices;
      public UsersController(IUsersServices iUsersServices)
    {
            _usersServices = iUsersServices;
    }
       
        // GET api/<Users>/5
        [HttpGet("{id}")]

        public async Task<ActionResult<User>> Get(int ind)
        {
            User user =await _usersServices.getUserById(ind);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        [HttpPost]
        // POST api/<Users>
        public async Task<ActionResult<User>> POST([FromBody] User user)
        {
            User postUser =await _usersServices.registerUser(user);
            if (postUser == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = postUser.UserId }, postUser);
        }

        [HttpPost ("login")]
       public async Task<ActionResult<User>> Post([FromBody] UserLog userToLog)
       {
            User user  =await _usersServices.loginUser(userToLog);
            if (user == null)
                return NoContent();
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Put(int id, [FromBody] User userToUpdate)
        {
            User postUser =await _usersServices.updateUser(userToUpdate,id);
            if (postUser == null)
                return BadRequest("Password is not strong enough");
            return CreatedAtAction(nameof(Get), new { id = postUser.UserId }, postUser);
        }

    }
}
