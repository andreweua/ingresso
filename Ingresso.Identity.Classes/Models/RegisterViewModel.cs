using System.ComponentModel.DataAnnotations;

namespace Ingresso.Identity.Classes
{
    public class RegisterViewModel
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
        [Display(Name = "Confirme a Senha")]
        [Compare("Password", ErrorMessage = "A senha deve ser igual à confirmação.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public string DocumentNumber { get; set; }

        [Display(Name = "Nascimento")]
        public string BirthDate { get; set; }

        [Display(Name = "Sexo")]
        public Gender Gender { get; set; }

        [Required]
        [Display(Name = "Logradouro")]
        public string AddressDescription { get; set; }

        [Display(Name = "Número")]
        public string AddressNumber { get; set; }

        [Display(Name = "Complemento")]
        public string AddressComplement { get; set; }

        [Display(Name = "CEP")]
        public string AddressZipCode { get; set; }

        [Required]
        [Display(Name = "Bairro")]
        public string AddressNeighborhood { get; set; }

        [Required]
        [Display(Name = "Cidade")]
        public string AddressCity { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string AddressState { get; set; }
    }
}
