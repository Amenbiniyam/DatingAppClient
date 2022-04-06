using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        // we have to declear first in order to use it in Constructor 
        // in Dependency injection
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            // here we have access to the database
            _context = context;
        }
        [HttpGet]
        // IEnumerable and List method has the same uses
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            
            return _context.Users.ToList(); ;
        }

        // api/users/3
        [HttpGet("{id}")]
        // IEnumerable and List method has the same uses
        public ActionResult<AppUser> GetUsers(int id)
        {
            return _context.Users.Find(id);
        }
    }


}
