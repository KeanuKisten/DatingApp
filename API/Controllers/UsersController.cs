using Microsoft.AspNetCore.Mvc;
using API.Data;
using System.Collections.Generic;
using System.Linq;
using API.Entities;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //could of user <List<AppUser>> aswell
            return await _context.Users.ToListAsync();
            
        }

        //api/users/3 - what HttpGet("{id}") does
        [HttpGet("{id}")]
        public async Task<ActionResult <AppUser>> GetUser(int id)
        {
            //could of user <List<AppUser>> aswell
            return await _context.Users.FindAsync(id);
            
        }
    }
}