using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApiController
    {
        // we have to declear first in order to use it in Constructor 
        // in Dependency injection
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            // here we have access to the database
            _context = context;
        }
        [AllowAnonymous]
        [HttpGet]
        // IEnumerable and List method has the same uses
        // We use Async to make our db query fast while other quering no need to wait 
        public async  Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            
            return await _context.Users.ToListAsync();
        }
        // api/users/3
        [Authorize]
        [HttpGet("{id}")]
        // IEnumerable and List method has the same uses
        public async Task<ActionResult<AppUser>> GetUsers(int id)
        {
            return await _context.Users.FindAsync(id);
        }
    }


}
