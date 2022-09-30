using Microsoft.AspNetCore.Mvc;
using BlogApi.Controllers.Dto.User;
using BlogApi.Data;
using BlogApi.Repositories;

namespace BlogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost]
        public IActionResult AddUser(CreateUserDto createUserDto)
        {
            if (ModelState.IsValid)
            {
                var user = new Models.User()
                {
                    DisplayName = createUserDto.DisplayName,
                    Email = createUserDto.Email,
                    Phone = createUserDto.Phone,
                    DateOfBirth = createUserDto.DateOfBirth,
                    Address = createUserDto.Address
                };
                var createUser = _userRepository.InsertUser(user);
                return Ok(createUser);
            }
            else
            {
                return BadRequest(ModelState.ErrorCount);
            }

        }
    }
}