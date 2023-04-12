using DbConnectionLibrary;
using EntityLibrary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        [EnableCors("Access-Control-Allow-Origin")]
        [HttpPost("{employer_id}/{category_id}")]
        public string AddOrder(int employer_id, int category_id, [FromBody] Order order)
        {
            DbManager db = new DbManager();
            string response = db.TableUsersOrder.AddOrder(employer_id, category_id ,order);

            return response;
        }

        [EnableCors("Access-Control-Allow-Origin")]
        [HttpGet("{category_id}")]
        public List<Order> GetOrdersByCategory(int category_id)
        {
            DbManager db = new DbManager();
            List<Order> orders = db.TableOrder.GetOrdersByCategory(category_id);

            return orders;
        }

        [EnableCors("Access-Control-Allow-Origin")]
        [HttpPut("{employerId}/{orderId}")]
        public void AcceptOrder(int employerId, int orderId)
        {
            DbManager db = new DbManager();
            db.TableOrder.AcceptOrder(employerId, orderId);

        }
    }
}
