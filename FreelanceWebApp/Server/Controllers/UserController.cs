using DbConnectionLibrary;
using EntityLibrary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [EnableCors("Access-Control-Allow-Origin")]
        [HttpPost("{login}/{password}")]
        public User FindUserByLoginAndPassword(string login, string password)
        {
            DbManager db = new DbManager();

            User findUser = db.TableUser.GetUserByLoginAndPassword(login, password);

            if (findUser != null)
                return findUser;
            else
                return null;
        }

        [EnableCors("Access-Control-Allow-Origin")]
        [HttpPut]
        public string AddUser([FromBody] User user)
        {
            DbManager db = new DbManager();
            string response = db.TableUser.AddUser(user);

            return response;
        }


    }
}
