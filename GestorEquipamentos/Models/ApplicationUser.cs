namespace GestorEquipamentos.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Phone]
        public string Telefone { get; set; }
    }

}
