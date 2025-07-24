using PedidoSoap;

namespace dm113_pedidos.ClientConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Bem vindo ao Sistema de Pedidos com SOAP!\n");
                Console.WriteLine("Digite 1 para listar os Produtos Disponíveis");
                Console.WriteLine("Digite 2 para listar os Pedidos");
                Console.WriteLine("Digite 3 para buscar Pedido por ID do Pedido");
                Console.WriteLine("Digite -1 para sair :(");

                Console.WriteLine("Informe sua opção");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        listarProdutos();
                        break;
                    case 2:
                        listarPedidos();
                        break;
                    case 3:
                        buscarPedidoId();
                        break;
                    case -1:
                        Console.Clear();
                        Console.WriteLine("Até logo!");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        break;
                }
                Thread.Sleep(1500);
                Console.Clear();
            }
        }

        private static void buscarPedidoId()
        {
            PedidoServiceClient client = new PedidoServiceClient(PedidoServiceClient.EndpointConfiguration.BasicHttpBinding_IPedidoService);
            client.Open();
            Console.WriteLine("Digite o ID do pedido que deseja buscar:");
            int idPedido = int.Parse(Console.ReadLine());
            var pedidoTask = client.ObterPedidoPorIdAsync(idPedido);
            pedidoTask.Wait();
            var pedido = pedidoTask.Result;
            if (pedido == null)
            {
                Console.WriteLine($"Pedido com ID {idPedido} não encontrado.");
            }
            else
            {
                Console.WriteLine($"Pedido encontrado: Id: {pedido.IdPedido}, Cliente: {pedido.NomeCliente}, Data: {pedido.DataPedido}, Valor Total: {pedido.Total}");
                foreach (var item in pedido.ItemPedidoList)
                {
                    Console.WriteLine($"  Item Id: {item.IdItemPedido}, Produto: {item.NomeProduto}, Quantidade: {item.Quantidade}, Preço Unitário: {item.PrecoUnitario}, Preço Final: {item.Total}");
                }
            }
        }

        private static void listarPedidos()
        {
            PedidoServiceClient client = new PedidoServiceClient(PedidoServiceClient.EndpointConfiguration.BasicHttpBinding_IPedidoService);
            client.Open();
            Console.WriteLine("Listando pedidos:");
            var pedidosTask = client.ListarPedidosAsync();
            pedidosTask.Wait();
            var pedidos = pedidosTask.Result;
            if (pedidos == null || pedidos.Length == 0)
            {
                Console.WriteLine("Nenhum pedido encontrado.");
            }
            else
            {
                Console.WriteLine($"Total de pedidos encontrados: {pedidos.Length}");
                foreach (var pedido in pedidos)
                {
                    Console.WriteLine($"Id: {pedido.IdPedido}, Cliente: {pedido.NomeCliente}, Data: {pedido.DataPedido}, Valor Total: {pedido.Total}");
                    foreach (var item in pedido.ItemPedidoList)
                    {
                        Console.WriteLine($"  Item Id: {item.IdItemPedido}, Produto: {item.NomeProduto}, Quantidade: {item.Quantidade}, Preço Unitário: {item.PrecoUnitario}, Preço Final: {item.Total}");
                    }
                }
            }
            client.Close();
        }

        private static void listarProdutos()
        {
            PedidoServiceClient client = new PedidoServiceClient(PedidoServiceClient.EndpointConfiguration.BasicHttpBinding_IPedidoService);
            client.Open();
            Console.WriteLine("Listando produtos:");
            var produtosTask = client.ListarProdutosAsync();
            produtosTask.Wait();
            var produtos = produtosTask.Result;
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Id: {produto.IdProduto} Nome: {produto.Nome} Preço: {produto.PrecoUnitario}");
            }
            client.Close();
        }
    }
}