using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace BlogApi.Controllers.Dto.User
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Ten hien thi khong the bo trong")]
        [DataType(DataType.Text)]
        public String DisplayName { get; set; }
        [Required(ErrorMessage = "Email khong the bo trong")]
        [EmailAddress]
        public String Email { get; set; }
        [Required(ErrorMessage = "Phone khong the bo trong")]
        public String Phone { get; set; }
        [Required(ErrorMessage = "Ngay Sinh khong the bo trong")]
        public DateTime DateOfBirth { get; set; }
        public String Address { get; set; }
    }
}