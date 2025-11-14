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
        UsersServices service=new UsersServices();
        // GET: api/<Users>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "user1", "user2" };
        }

        // GET api/<Users>/5
        [HttpGet("{id}")]

        public ActionResult<User> Get(int ind)
        {
            User user=service.getUserById(ind);
            if (user == null)
                return NoContent();
            return Ok(user);
        }

        [HttpPost]
        // POST api/<Users>
        public ActionResult <User> POST([FromBody] User user)
        {
            User postUser=service.registerUser(user);
            if (postUser == null)
                return BadRequest();
            return CreatedAtAction(nameof(Get), new { id = postUser.userId }, postUser);
        }

        [HttpPost ("login")]
       public ActionResult<User> Post([FromBody] UserLog userToLog)
       {
            User user = service.loginUser(userToLog);
            if (user == null)
                return NoContent();
            return CreatedAtAction(nameof(Get), new { id = user.userId }, user);
        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User userToUpdate)
        {
            service.updateUser(userToUpdate,id);
        }
        

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
