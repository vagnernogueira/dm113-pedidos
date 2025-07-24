namespace dm113_pedidos.Model
{
    public static class ModelUtil
    {
        public static void Print(Pedido? pedido)
        {
            if (pedido == null)
            {
                Console.WriteLine("Referência nula para Pedido.");
                return;
            }
            Console.WriteLine($"Pedido ID: {pedido.IdPedido}");
            Console.WriteLine($"Cliente: {pedido.NomeCliente}");
            Console.WriteLine($"Data do Pedido: {pedido.DataPedido}");
            Console.WriteLine($"Total: {pedido.Total:C}");
            Console.WriteLine($"Status: {pedido.Status}");
            if (pedido.ItemPedidoList != null && pedido.ItemPedidoList.Count > 0)
            {
                Console.WriteLine("Itens do Pedido:");
                pedido.ItemPedidoList.ForEach(item => Print(item));
            }
            else
            {
                Console.WriteLine("Nenhum item no pedido.");
            }
            Console.WriteLine("\r\n");
        }
        public static void Print(ItemPedido? itemPedido)
        {
            if (itemPedido == null)
            {
                Console.WriteLine("Referência nula para ItemPedido.");
                return;
            }
            Console.WriteLine($"- Pedido ID: {itemPedido.IdPedido}, Item Pedido ID: {itemPedido.IdItemPedido}, Produto ID: {itemPedido.IdProduto}, Nome do Produto: {itemPedido.NomeProduto}, Quantidade: {itemPedido.Quantidade}, Preço Unitário: {itemPedido.PrecoUnitario:C}, Total: {itemPedido.Total:C}");
        }
        public static void Print(Produto? produto)
        {
            if (produto == null)
            {
                Console.WriteLine("Referência nula para Produto.");
                return;
            }
            Console.WriteLine($"Produto ID: {produto.IdProduto}, Nome: {produto.Nome}, Descrição: {produto.Descricao}, Preço Unitário: {produto.PrecoUnitario:C}");
        }
        public static void PrintKeys<T>(Dictionary<int, T> dict)
        {
            foreach (var key in dict.Keys)
            {
                Console.WriteLine(key);
            }
        }
        private static int GetNextKey<T>(Dictionary<int, T> dict)
        {
            return dict.Keys.Any() ? dict.Keys.Max() + 1 : 1;
        }
        public static void PrintValues<T>(Dictionary<int, T> dict)
        {
            foreach (var value in dict.Values)
            {
                if (value is Produto produto)
                {
                    Print(produto);
                }
                else if (value is Pedido pedido)
                {
                    Print(pedido);
                }
                else if (value is ItemPedido itemPedido)
                {
                    Print(itemPedido);
                }
            }
        }
        public static Produto AjustarDados(Produto? produto, Dictionary<int, Produto> produtos)
        {
            if (produto == null)
            {
                produto = new Produto();
            }
            if (produto.IdProduto <= 0 || !produtos.ContainsKey(produto.IdProduto))
            {
                produto.IdProduto = GetNextKey(produtos);
            }
            if (string.IsNullOrEmpty(produto.Nome))
            {
                produto.Nome = "Produto sem nome";
            }
            if (produto.PrecoUnitario <= 0)
            {
                produto.PrecoUnitario = 0.01m;
            }
            return produto;
        }
        public static Pedido AjustarDados(Pedido? pedido, Dictionary<int, Pedido> pedidos)
        {
            if (pedido == null)
            {
                pedido = new Pedido();
            }
            if (pedido.IdPedido <= 0 || !pedidos.ContainsKey(pedido.IdPedido))
            {
                pedido.IdPedido = GetNextKey(pedidos);
            }
            if (string.IsNullOrEmpty(pedido.NomeCliente))
            {
                pedido.NomeCliente = "Cliente sem nome";
            }
            if (string.IsNullOrEmpty(pedido.DataPedido))
            {
                pedido.DataPedido = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
            if (pedido.ItemPedidoList == null)
            {
                pedido.ItemPedidoList = new List<ItemPedido>();
            }
            pedido.Total = pedido.ItemPedidoList.Sum(item => item.PrecoUnitario * item.Quantidade);
            if (string.IsNullOrEmpty(pedido.Status))
            {
                pedido.Status = "Pendente";
            }
            return pedido;
        }
    }
}
