using BlogApi.Controllers.Dto.User;
using BlogApi.Data;
using BlogApi.Models;

namespace BlogApi.Repositories
{
    public class UserRepository
    {
        private readonly AppDbContext _appDbContext;
        public UserRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public UserDto InsertUser(User user)
        {
            _appDbContext.Users.Add(user);
            _appDbContext.SaveChanges();
            var results = new UserDto()
            {
                DisplayName = user.DisplayName,
                ID = user.ID,
                Email = user.Email,
                Phone = user.Phone,
                Address = user.Address,
                DateOfBirth = user.DateOfBirth,
            };
            return results;
        }
    }
}