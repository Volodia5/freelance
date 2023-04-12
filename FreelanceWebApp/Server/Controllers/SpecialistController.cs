using DbConnectionLibrary;
using EntityLibrary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialistController : ControllerBase
    {
        [EnableCors("Access-Control-Allow-Origin")]
        [HttpPost("{categoryId}")]
        public List<User> GetSpecialistsByCategory(int categoryId)
        {
            DbManager db = new DbManager();

            List<User> specialists = db.TableUser.GetAllSpecialistsByCategory(categoryId);

            return specialists;
        }

        [EnableCors("Access-Control-Allow-Method")]
        [HttpPut("{specialistId}/{orderId}")]
        public void AcceptOrder(int specialistId, int orderId)
        {
            DbManager db = new DbManager();

            db.TableUsersOrder.UpdateOrderWithEmployerId(specialistId, orderId);
        }
    }
}
