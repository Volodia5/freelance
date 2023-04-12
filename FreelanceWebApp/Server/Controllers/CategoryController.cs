using DbConnectionLibrary;
using EntityLibrary;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [EnableCors("Access-Control-Allow-Origin")]
        [HttpGet]
        public List<Category> GetCategories()
        {
            DbManager db = new DbManager();
            List<Category> categories = db.TableCategories.GetAllCategories();

            return categories;
        }

    }
}
