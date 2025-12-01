using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiShop.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordController : ControllerBase
    {
        IPasswordService _passwordService;
        public PasswordController(IPasswordService _passwordService)
        { 
            this._passwordService = _passwordService;
        }

        // POST api/<PasswordController>
        [HttpPost]
        public ActionResult<CheckPassowrd> Post([FromBody] string password)
        {
            return Ok(_passwordService.checkStrengthPassword(password));
        }
    }
}
