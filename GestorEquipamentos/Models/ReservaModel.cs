using System.ComponentModel.DataAnnotations;

namespace GestorEquipamentos.Models
{
    public class ReservaModel
    {
        public ReservaModel()
        {
            this.Status = "Pendente";
        }

        public int Id { get; set; }
        [Required]
        public string UsuarioId { get; set; }
        [Required]
        public string ProdutoId { get; set; }
        public string Status { get; set; }
        [Required]
        public DateTime DataSolicitacao { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }

        [Required]
        public DateTime DataTermino { get; set; }
    }
}
