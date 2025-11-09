using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WepApiShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        string filePath = "M:\\Wep API\\WepApiShop\\WepApiShop\\usersFile.txt";
        // GET: api/<Users>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "user1", "user2" };
        }

        // GET api/<Users>/5
        UserClass[] uc = new UserClass[5];
        int i = 0;
       
        [HttpGet("{id}")]

        public ActionResult<UserClass> Get(int ind)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UserClass user = JsonSerializer.Deserialize<UserClass>(currentUserInFile);
                    if (user.userId == ind)
                        return user;
                }
            }
            return NoContent();
        }

        [HttpPost]
        // POST api/<Users>
        public ActionResult <UserClass> POST([FromBody] UserClass user)
        {
            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.userId = numberOfUsers+1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.userId }, user);
        }
        [HttpPost ("login")]
       public ActionResult<UserClass> Post([FromBody] UserLog userToLog)
       {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    UserClass user = JsonSerializer.Deserialize<UserClass>(currentUserInFile);
                    if (user.userName == userToLog.userName && user.password == userToLog.password)
                        return CreatedAtAction(nameof(Get), new { id = user.userId }, user);
                }
            }
            return NoContent();
        }



        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] UserClass userToUpdate)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    UserClass user = JsonSerializer.Deserialize<UserClass>(currentUserInFile);
                    if (user.userId == id)
                    {
                        textToReplace = currentUserInFile;
                    }
                }
            }

            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(userToUpdate));
                System.IO.File.WriteAllText(filePath, text);
            }

        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
