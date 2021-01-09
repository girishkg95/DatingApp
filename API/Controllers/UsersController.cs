using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext context;
        public UsersController(DataContext context)
        {
            this.context = context;
        }

        /* [HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            var users = context.Users.ToList();
            return users;
            //return context.Users.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<AppUser> GetUser(int id)
        {
            var user = context.Users.Find(id);
            return user;
            //return context.Users.Find(id)
        } */

        //Asynchronous communication

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await context.Users.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await context.Users.FindAsync(id);
        }
    }
}