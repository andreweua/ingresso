using System.ComponentModel.DataAnnotations;

namespace Ingresso.Identity.Classes
{
    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} caracteres.", MinimumLength = IdentityHelper.MinimumPasswordLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmação")]
        [Compare("Password", ErrorMessage = "A senha deve ser igual à confirmação.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }
}
