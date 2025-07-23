using dm113_pedidos.Model;
using System.ServiceModel;

namespace dm113_pedidos.Service
{
    [ServiceContract]
    public interface IPedidoService
    {
        [OperationContract]
        Pedido[] ListarPedidos();

        [OperationContract]
        Pedido ObterPedidoPorId(int id);

        [OperationContract]
        int CriarPedido(Pedido pedido);

        [OperationContract]
        void AtualizarPedido(Pedido pedido);

        [OperationContract]
        void ExcluirPedido(int id);

        [OperationContract]
        void AdicionarItemAoPedido(int pedidoId, ItemPedido item);

        [OperationContract]
        void RemoverItemDoPedido(int pedidoId, int itemId);

        [OperationContract]
        void AtualizarItemDoPedido(int pedidoId, ItemPedido item);

        [OperationContract]
        ItemPedido[] ListarItensDoPedido(int pedidoId);

        [OperationContract]
        Pedido[] ListarPedidosPorStatus(string status);

        [OperationContract]
        Pedido[] ListarPedidosPorCliente(string nomeCliente);

        [OperationContract]
        Pedido[] ListarPedidosPorData(DateTime dataInicial, DateTime dataFinal);

        [OperationContract]
        Produto[] ListarProdutos();

        [OperationContract]
        Produto ObterProdutoPorId(int id);

        [OperationContract]
        string CriarProduto(Produto produto);

        [OperationContract]
        string AtualizarProduto(Produto produto);

        [OperationContract]
        void ExcluirProduto(int id);
    }
    public class PedidoService : IPedidoService
    {
        Dictionary<int, Produto> produtos = new Dictionary<int, Produto>()
        {
            { 1, new Produto { IdProduto = 1, Nome = "Mario Kart World", Descricao = "Jogo de corrida para Nintendo Switch", PrecoUnitario = 499.90m } },
            { 2, new Produto { IdProduto = 2, Nome = "Cyberpunk 2077: Ultimate Edition", Descricao = "Jogo de RPG de ação", PrecoUnitario = 304.99m } },
            { 3, new Produto { IdProduto = 3, Nome = "Legend of Zelda: Tears of the Kingdom", Descricao = "Jogo de aventura para Nintendo Switch", PrecoUnitario = 499.90m } },
            { 4, new Produto { IdProduto = 4, Nome = "Console Nintendo Switch 2", Descricao = "Console de videogame da Nintendo", PrecoUnitario = 5124.39m } },
            { 5, new Produto { IdProduto = 5, Nome = "Console PlayStation 5 Pro", Descricao = "Console de videogame da Sony", PrecoUnitario = 6602.07m } },
            { 6, new Produto { IdProduto = 6, Nome = "Console Xbox Series X", Descricao = "Console de videogame da Microsoft", PrecoUnitario = 5799.00m } },
            { 7, new Produto { IdProduto = 7, Nome = "Assinatura Game Pass 12 meses", Descricao = "Xbox Game Pass Ultimate Gpu 12 Meses Codigo Brasileiro Br", PrecoUnitario = 329.99m } }
        };

        Dictionary<int, Pedido> pedidos = new Dictionary<int, Pedido>();

        public Produto[] ListarProdutos()
        {
            return produtos.Values.ToArray();
        }
        public string CriarProduto(Produto produto)
        {
            try
            {
                if (produtos.ContainsKey(produto.IdProduto))
                {
                    throw new Exception("Não é possível cadastrar Produto com ID já cadastrado!");
                }
                produtos.Add(produto.IdProduto, produto);
                return produto.IdProduto.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public string AtualizarProduto(Produto produto)
        {
            try
            {
                if (!produtos.ContainsKey(produto.IdProduto))
                {
                    throw new InvalidOperationException("ID não encontrado!");
                }
                produtos[produto.IdProduto] = produto;
                return produto.IdProduto.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public Produto ObterProdutoPorId(int id)
        {
            try
            {
                if (!produtos.ContainsKey(id))
                {
                    throw new InvalidOperationException("ID não encontrado!");
                }
                return produtos[id];
            }
            catch (Exception)
            {
                return new Produto();
            }
        }

        public void ExcluirProduto(int id)
        {
            try
            {
                if (!produtos.ContainsKey(id))
                {
                    throw new InvalidOperationException("ID não encontrado!");
                }
                produtos.Remove(id);
            }
            catch (Exception)
            {
            }
        }
        public Pedido[] ListarPedidos()
        {
            return pedidos.Values.ToArray();
        }

        public Pedido[] ListarPedidosPorCliente(string nomeCliente)
        {
            return pedidos.Values.Where(p => p.NomeCliente.Equals(nomeCliente, StringComparison.OrdinalIgnoreCase)).ToArray();
        }

        public Pedido[] ListarPedidosPorData(DateTime dataInicial, DateTime dataFinal)
        {
            return pedidos.Values
                .Where(p => p.DataPedido >= dataInicial && p.DataPedido <= dataFinal)
                .ToArray();
        }

        public Pedido[] ListarPedidosPorStatus(string status)
        {
            return pedidos.Values
                .Where(p => p.Status.Equals(status, StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }

        public Pedido ObterPedidoPorId(int id)
        {
            try
            {
                if(!pedidos.ContainsKey(id))
                {
                    throw new InvalidOperationException("ID não encontrado!");
                }
                return pedidos[id];
            }
            catch (Exception)
            {
                return new Pedido();
            }
        }

        public int CriarPedido(Pedido pedido)
        {
            try
            {
                if (produtos.ContainsKey(pedido.IdPedido))
                {
                    throw new Exception("Não é possível cadastrar Produto com ID já cadastrado!");
                }
                produtos.Add(produto.IdProduto, produto);
                return produto.IdProduto.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public void ExcluirPedido(int id)
        {
            throw new NotImplementedException();
        }

        public void AtualizarPedido(Pedido pedido)
        {
            throw new NotImplementedException();
        }

        public void AdicionarItemAoPedido(int pedidoId, ItemPedido item)
        {
            throw new NotImplementedException();
        }

        public void AtualizarItemDoPedido(int pedidoId, ItemPedido item)
        {
            throw new NotImplementedException();
        }

        public ItemPedido[] ListarItensDoPedido(int pedidoId)
        {
            throw new NotImplementedException();
        }

        public void RemoverItemDoPedido(int pedidoId, int itemId)
        {
            throw new NotImplementedException();
        }
    }
}
