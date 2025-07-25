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
        string CriarPedido(Pedido pedido);
        [OperationContract]
        string AtualizarPedido(Pedido pedido);
        [OperationContract]
        void ExcluirPedido(int id);
        [OperationContract]
        void AdicionarItemAoPedido(int idPedido, ItemPedido item);
        [OperationContract]
        void RemoverItemDoPedido(int idPedido, int idItem);
        [OperationContract]
        ItemPedido[] ListarItensDoPedido(int idPedido);
        [OperationContract]
        Pedido[] ListarPedidosPorStatus(string status);
        [OperationContract]
        Pedido[] ListarPedidosPorCliente(string nomeCliente);
        [OperationContract]
        Pedido[] ListarPedidosPorData(string dataInicial, string dataFinal);
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
        Dictionary<int, Produto> produtos = new()
        {
            { 1, new Produto { IdProduto = 1, Nome = "Mario Kart World", Descricao = "Jogo de corrida para Nintendo Switch", PrecoUnitario = 499.90m } },
            { 2, new Produto { IdProduto = 2, Nome = "Cyberpunk 2077: Ultimate Edition", Descricao = "Jogo de RPG de ação", PrecoUnitario = 304.99m } },
            { 3, new Produto { IdProduto = 3, Nome = "Legend of Zelda: Tears of the Kingdom", Descricao = "Jogo de aventura para Nintendo Switch", PrecoUnitario = 499.90m } },
            { 4, new Produto { IdProduto = 4, Nome = "Console Nintendo Switch 2", Descricao = "Console de videogame da Nintendo", PrecoUnitario = 5124.39m } },
            { 5, new Produto { IdProduto = 5, Nome = "Console PlayStation 5 Pro", Descricao = "Console de videogame da Sony", PrecoUnitario = 6602.07m } },
            { 6, new Produto { IdProduto = 6, Nome = "Console Xbox Series X", Descricao = "Console de videogame da Microsoft", PrecoUnitario = 5799.00m } },
            { 7, new Produto { IdProduto = 7, Nome = "Assinatura Game Pass 12 meses", Descricao = "Xbox Game Pass Ultimate Gpu 12 Meses Codigo Brasileiro Br", PrecoUnitario = 329.99m } }
        };
        Dictionary<int, Pedido> pedidos = [];
        /** 
         * Métodos de serviço para gerenciar PRODUTOS.
         */
        public Produto[] ListarProdutos()
        {
            return produtos.Values.ToArray();
        }
        public string CriarProduto(Produto produto)
        {
            try
            {
                ModelUtil.AjustarDados(produto, produtos);
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
                produtos[produto.IdProduto] = ModelUtil.AjustarDados(produto, produtos);
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
                return ModelUtil.AjustarDados(produtos[id], produtos);
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
                produtos.Remove(id);
            }
            catch (Exception)
            {
            }
        }
        /** 
         * Métodos de serviço para gerenciar PEDIDOS.
         */
        public Pedido[] ListarPedidos()
        {
            Console.WriteLine("ListarPedidos");
            ModelUtil.PrintKeys(pedidos);
            return pedidos.Values.ToArray();
        }
        public Pedido[] ListarPedidosPorCliente(string nomeCliente)
        {
            return pedidos.Values
                .Where(p => p.NomeCliente.Equals(nomeCliente.Trim(), StringComparison.OrdinalIgnoreCase))
                .ToArray();
        }
        public Pedido[] ListarPedidosPorData(string dataInicial, string dataFinal)
        {
            return pedidos.Values
                .Where(p => 
                    DateTime.TryParse(p.DataPedido, out DateTime dataPedido) && 
                    dataPedido >= DateTime.Parse(dataInicial) && 
                    dataPedido <= DateTime.Parse(dataFinal))
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
            Console.WriteLine("ObterPedidoPorId");
            ModelUtil.PrintKeys(pedidos);
            try
            {
                return ModelUtil.AjustarDados(pedidos[id], pedidos);
            }
            catch (Exception)
            {
                return new Pedido();
            }
        }
        public string CriarPedido(Pedido pedido)
        {
            try
            {
                ModelUtil.AjustarDados(pedido, pedidos);
                pedidos.Add(pedido.IdPedido, pedido);
                return pedido.IdPedido.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public void ExcluirPedido(int id)
        {
            try
            {
                pedidos.Remove(id);
            }
            catch (Exception)
            {
            }
        }
        public string AtualizarPedido(Pedido pedido)
        {
            Console.WriteLine("AtualizarPedido");
            ModelUtil.PrintKeys(pedidos);
            try
            {
                if (!pedidos.ContainsKey(pedido.IdPedido))
                {
                    throw new KeyNotFoundException("Pedido não encontrado.");
                }
                ModelUtil.AjustarDados(pedido, pedidos);
                pedidos[pedido.IdPedido] = pedido;
                return pedido.IdPedido.ToString();
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public void AdicionarItemAoPedido(int idPedido, ItemPedido item)
        {
            try
            {
                Pedido pedido = ModelUtil.AjustarDados(pedidos[idPedido], pedidos);
                bool novoItem = true;
                foreach (var itemExistente in pedido.ItemPedidoList)
                {
                    if (itemExistente.IdProduto == item.IdProduto)
                    {
                        itemExistente.Quantidade += item.Quantidade;
                        novoItem = false;
                        break;
                    }
                }
                if (novoItem)
                {
                    item = ModelUtil.AjustarDados(item, pedido, produtos);
                    pedido.ItemPedidoList.Add(item);
                }
            }
            catch (Exception)
            {
            }
        }

        public ItemPedido[] ListarItensDoPedido(int idPedido)
        {
            return ModelUtil.AjustarDados(pedidos[idPedido], pedidos).ItemPedidoList.ToArray();
        }
        public void RemoverItemDoPedido(int idPedido, int idItem)
        {
            ModelUtil.AjustarDados(pedidos[idPedido], pedidos).ItemPedidoList.RemoveAll(item => item.IdItemPedido == idItem);
        }
    }
}
