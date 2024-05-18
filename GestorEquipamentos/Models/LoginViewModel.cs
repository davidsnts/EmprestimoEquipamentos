using System.ComponentModel.DataAnnotations;

namespace GestorEquipamentos.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O Email é obrigatório")]
        [EmailAddress]
        public string? Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }


        [Display(Name = "Lembrar-me")]
        public bool RememberMe { get; set; }
    }
}
