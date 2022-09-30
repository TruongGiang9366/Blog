namespace BlogApi.Controllers.Dto.User
{
    public class UserDto
    {
        public Guid ID { get; set; }
        public String DisplayName { get; set; }
        public String Email { get; set; }
        public String Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public String Phone { get; set; }
    }
}