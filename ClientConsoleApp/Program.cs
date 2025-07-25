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
                Console.WriteLine("Digite 4 para registrar um Pedido");
                Console.WriteLine("Digite 5 para adicionar item ao Pedido");
                Console.WriteLine("Digite 6 para excluir um Pedido");
                Console.WriteLine("Digite -1 para sair :(");

                Console.WriteLine("Informe sua opção");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        ListarProdutos();
                        break;
                    case 2:
                        ListarPedidos();
                        break;
                    case 3:
                        BuscarPedidoId();
                        break;
                    case 4:
                        RegistrarPedido();
                        break;
                    case 5:
                        AdicionarItemPedido();
                        break;
                    case 6:
                        ExcluirPedido();
                        break;
                    case -1:
                        Console.Clear();
                        Console.WriteLine("Que a Força esteja com você!");
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
        private static void ExcluirPedido()
        {
            PedidoServiceClient client = new (PedidoServiceClient.EndpointConfiguration.BasicHttpBinding_IPedidoService);
            client.Open();
            Console.WriteLine("Digite o ID do pedido que deseja excluir:");
            int idPedido = int.Parse(Console.ReadLine());
            var resultadoTask = client.ExcluirPedidoAsync(idPedido);
            resultadoTask.Wait();
            Console.WriteLine("Operação realizada.");
            client.Close();
        }
        private static void AdicionarItemPedido()
        {
            PedidoServiceClient client = new (PedidoServiceClient.EndpointConfiguration.BasicHttpBinding_IPedidoService);
            client.Open();
            Console.WriteLine("Digite o ID do pedido ao qual deseja adicionar um item:");
            int idPedido = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o ID do produto que deseja adicionar:");
            int idProduto = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite a quantidade do produto:");
            int quantidade = int.Parse(Console.ReadLine());
            var itemPedido = new ItemPedido
            {
                IdItemPedido = 0,
                IdPedido = idPedido,
                IdProduto = idProduto,
                NomeProduto = string.Empty,
                Quantidade = quantidade,
                PrecoUnitario = 0,
                Total = 0
            };
            var resultadoTask = client.AdicionarItemAoPedidoAsync(idPedido, itemPedido);
            resultadoTask.Wait();
            Console.WriteLine("Item adicionado ao pedido com sucesso.");
            client.Close();
        }
        private static void RegistrarPedido()
        {
            PedidoServiceClient client = new (PedidoServiceClient.EndpointConfiguration.BasicHttpBinding_IPedidoService);
            client.Open();
            Console.WriteLine("Digite o nome do cliente:");
            string nomeCliente = Console.ReadLine();
            var pedido = new Pedido
            {
                IdPedido = 0,
                NomeCliente = nomeCliente,
                DataPedido = string.Empty,
                Total = 0,
                ItemPedidoList = new ItemPedido[0]
            };
            var resultadoTask = client.CriarPedidoAsync(pedido);
            resultadoTask.Wait();
            var resultado = resultadoTask.Result;
            Console.WriteLine("Retorno do serviço SOAP. Retorno numérico é o ID do Pedido criado.");
            Console.WriteLine($" {resultado}");
            client.Close();
        }
        private static void BuscarPedidoId()
        {
            PedidoServiceClient client = new(PedidoServiceClient.EndpointConfiguration.BasicHttpBinding_IPedidoService);
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
                Console.WriteLine("Pessione qualquer tecla para retornar");
                Console.ReadKey();
            }
            client.Close();
        }
        private static void ListarPedidos()
        {
            PedidoServiceClient client = new (PedidoServiceClient.EndpointConfiguration.BasicHttpBinding_IPedidoService);
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
                Console.WriteLine("Pessione qualquer tecla para retornar");
                Console.ReadKey();
            }
            client.Close();
        }
        private static void ListarProdutos()
        {
            PedidoServiceClient client = new (PedidoServiceClient.EndpointConfiguration.BasicHttpBinding_IPedidoService);
            client.Open();
            Console.WriteLine("Listando produtos:");
            var produtosTask = client.ListarProdutosAsync();
            produtosTask.Wait();
            var produtos = produtosTask.Result;
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Id: {produto.IdProduto} Nome: {produto.Nome} Preço: {produto.PrecoUnitario}");
            }
            Console.WriteLine("Pessione qualquer tecla para retornar");
            Console.ReadKey();
            client.Close();
        }
    }
}