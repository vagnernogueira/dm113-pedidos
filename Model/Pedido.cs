using System.Runtime.Serialization;

namespace dm113_pedidos.Model
{
    [DataContract]
    public class Pedido
    {
        [DataMember]
        public int IdPedido { get; set; }
        [DataMember]
        public string NomeCliente { get; set; } = string.Empty;
        [DataMember]
        public DateTime DataPedido { get; set; } = DateTime.Now;
        [DataMember]
        public List<ItemPedido> ItemPedidoList { get; set; } = new List<ItemPedido>();
        [DataMember]
        public decimal Total => ItemPedidoList.Sum(item => item.PrecoUnitario * item.Quantidade);
        public string Status { get; set; } = "Pendente";
    }
}
