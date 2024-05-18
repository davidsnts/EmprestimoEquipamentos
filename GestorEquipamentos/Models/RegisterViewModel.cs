using System.ComponentModel.DataAnnotations;

namespace GestorEquipamentos.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "O nome deve ter entre 3 e 30 caracteres.")]
        public string? Nome { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirme a senha")]
        [Compare("Password", ErrorMessage = "As senhas não são iguais")]
        public string? ConfirmPassword { get; set; }
    }
}
