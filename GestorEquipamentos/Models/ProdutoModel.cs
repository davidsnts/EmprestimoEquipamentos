namespace GestorEquipamentos.Models
{
    public class ProdutoModel
    {
        public ProdutoModel()
        {
            this.Status = "Ativo";
        }

        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Status { get; set; }
    }
}
