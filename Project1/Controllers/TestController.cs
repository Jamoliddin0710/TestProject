using Mapster;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project1.DTO;
using Project1.Entity;

namespace Project1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
      
        public TestController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddUser(CreateUserDTO userDTo)
        {
            var user = userDTo.Adapt<User>();
            _context.Users.Add(user);
            _context.SaveChanges();
            return Ok(user);
        }
       
       
        [HttpGet("Users")]
        public IActionResult GetUser()
        {
            return Ok(_context.Users.ToList());
        }

        [HttpGet]
        public IActionResult GetUserById(int userId)
        {
            var user = _context.Users.FirstOrDefault(user=>user.Id==userId);
            if (user is null)
                throw new Exception("user is null");
            return Ok(user);
        }
    }
}
