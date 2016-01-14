using System.ComponentModel.DataAnnotations;

namespace Ingresso.Identity.Classes
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "E-mail")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Display(Name = "Me lembre")]
        public bool RememberMe { get; set; }
    }
}
