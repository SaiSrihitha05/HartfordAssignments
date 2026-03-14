using BasicAuthentication.DTOs;
using BasicAuthentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BasicAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext _context;

        public UserController(UserContext context)
        {
            _context = context;
        }
        [HttpPost("register")]
        public IActionResult Register(UserDTO userdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _context.User.FirstOrDefault(u => u.email == userdto.email);
            if (user == null)
            {
                var userdata = new User
                {
                    firstName = userdto.firstName,
                    lastName = userdto.lastName,
                    email = userdto.email,
                    password = userdto.password
                };
                _context.User.Add(userdata);
                _context.SaveChanges();
                return Ok("User Registered Successfully");
            }
            else
            {
                return BadRequest("User with this email is already registered.");
            }

        }

        [HttpPost("login")]
        public IActionResult Login(LoginDTO logindto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = _context.User.FirstOrDefault(u => u.email == logindto.email && u.password == logindto.password);
            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(user);
            }
        }
        [HttpGet]
        public IActionResult GetUserById(int id)
        {
            var user = _context.User.FirstOrDefault(u => u.userId == id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }
    }
}
