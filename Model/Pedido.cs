using System.Runtime.Serialization;

namespace dm113_pedidos.Model
{
    [DataContract]
    public class Pedido
    {
        [DataMember]
        public int IdPedido { get; set; }
        [DataMember]
        public string NomeCliente { get; set; }
        [DataMember]
        public string? DataPedido { get; set; }
        [DataMember]
        public List<ItemPedido>? ItemPedidoList { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public string Status { get; set; }
    }
}
