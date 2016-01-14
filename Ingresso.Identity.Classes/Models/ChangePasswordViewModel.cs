using System.ComponentModel.DataAnnotations;

namespace Ingresso.Identity.Classes
{
    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Senha Atual")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "A {0} deve ter ao menos {2} caracteres.", MinimumLength = IdentityHelper.MinimumPasswordLength)]
        [DataType(DataType.Password)]
        [Display(Name = "Nova Senha")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a Nova Senha")]
        [Compare("NewPassword", ErrorMessage = "A nova senha deve ser igual à confirmação.")]
        public string ConfirmPassword { get; set; }
    }
}
