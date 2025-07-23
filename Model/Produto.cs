using System.Runtime.Serialization;

namespace dm113_pedidos.Model
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public int IdProduto { get; set; }
        [DataMember]
        public string Nome { get; set; } = string.Empty;
        [DataMember]
        public string? Descricao { get; set; }
        [DataMember]
        public decimal PrecoUnitario { get; set; }
    }
}
