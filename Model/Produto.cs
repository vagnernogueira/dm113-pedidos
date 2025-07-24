using System.Runtime.Serialization;

namespace dm113_pedidos.Model
{
    [DataContract]
    public class Produto
    {
        [DataMember]
        public int IdProduto { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string? Descricao { get; set; }
        [DataMember]
        public decimal PrecoUnitario { get; set; }

        public void Print()
        {
            Console.WriteLine($"Produto ID: {IdProduto}, Nome: {Nome}, Descrição: {Descricao}, Preço Unitário: {PrecoUnitario:C}");
        }
    }
}
