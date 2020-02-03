using System.ComponentModel.DataAnnotations;

namespace WebStore.Models
{
    public class RegisterUserViewModel
    {

        [Required(AllowEmptyStrings = false, ErrorMessage = "Имя является обязательным для заполнения"), MaxLength(256)]
        public string UserName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "E-mail является обязательным для заполнения"),  DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Заполните пароль"), DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Заполните пароль"), DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}
