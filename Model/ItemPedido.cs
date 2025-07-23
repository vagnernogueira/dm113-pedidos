using System.Runtime.Serialization;

namespace dm113_pedidos.Model
{
    [DataContract]
    public class ItemPedido
    {
        [DataMember]
        public int IdItemPedido { get; set; }
        [DataMember]
        public int IdPedido { get; set; }
        [DataMember]
        public int IdProduto { get; set; }
        [DataMember]
        public string NomeProduto { get; set; } = string.Empty;
        [DataMember]
        public int Quantidade { get; set; }
        [DataMember]
        public decimal PrecoUnitario { get; set; }
        [DataMember]
        public decimal Total => Quantidade * PrecoUnitario;
    }
}
