using DbConnectionLibrary;
using EntityLibrary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        [EnableCors("Access-Control-Allow-Origin")]
        [HttpPost("{employerId}")]
        public List<Order> GetEmployerOrders(int employerId)
        {
            DbManager db = new DbManager();

            List<Order> orders = db.TableUsersOrder.GetOrdersByEmployerId(employerId);

            return orders;
        }

    }
}
