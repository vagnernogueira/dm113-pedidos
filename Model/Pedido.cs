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
        public void Print()
        {
            Console.WriteLine($"Pedido ID: {IdPedido}");
            Console.WriteLine($"Cliente: {NomeCliente}");
            Console.WriteLine($"Data do Pedido: {DataPedido}");
            Console.WriteLine($"Total: {Total:C}");
            Console.WriteLine($"Status: {Status}");
            if (ItemPedidoList != null && ItemPedidoList.Count > 0)
            {
                Console.WriteLine("Itens do Pedido:");
                ItemPedidoList.ForEach(item => item.Print());
            }
            else
            {
                Console.WriteLine("Nenhum item no pedido.");
            }
            Console.WriteLine("\r\n");
        }
    }
}
