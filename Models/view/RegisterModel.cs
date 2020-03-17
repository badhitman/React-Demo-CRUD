////////////////////////////////////////////////
// © https://github.com/badhitman - @fakegov 
////////////////////////////////////////////////
using System.ComponentModel.DataAnnotations;

namespace SPADemoCRUD.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.EmailAddress)]
        public string EmailRegister { get; set; }

        [Required(ErrorMessage = "Не указан Email")]
        [DataType(DataType.Text)]
        public string UsernameRegister { get; set; }

        [Required(ErrorMessage = "Не указан пароль")]
        [DataType(DataType.Password)]
        public string PasswordRegister { get; set; }

        [DataType(DataType.Password)]
        [Compare("PasswordRegister", ErrorMessage = "Пароль введен неверно")]
        public string ConfirmPasswordRegister { get; set; }
    }
}
