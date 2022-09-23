using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApi.Data;
using Microsoft.AspNetCore.Mvc;

namespace BlogApi.Controllers
{
    
    
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TestController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetData(){
            return Ok (new 
            {
                status = "ok",
                data = "Success"
            });
        }
        [HttpPost]
        public IActionResult PostData()
        {
            _context.Users.Add(new Models.User(){
                DisplayName = "User Test",
                Email = "test@gmail.com",
                Phone = "01484984643",
                Address = "Huynh Van Nghe",
                DateOfBirth = DateTime.UtcNow
            });
            _context.SaveChanges();
            return Ok(User);
        }
    }
}