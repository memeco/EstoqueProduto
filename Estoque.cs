using System.Collections.Generic;

namespace SistemaDeProdutos
{
    public class Estoque
    {
        private Dictionary<int, int>_produtos = new Dictionary<int, int>();

        public void AdicionarProduto(Produto produto, int quantidade)
        {
            if(_produtos.ContainsKey(produto.Id))
            {
                _produtos[produto.Id] += quantidade;
            }
            else
            {
                _produtos.Add(produto.Id, quantidade);
            }
        }

        public bool RemoverProduto(Produto produto, int quantidade)
        {
            if (_produtos.ContainsKey(produto.Id) && _produtos[produto.Id] >= quantidade)
            {
                _produtos[produto.Id] -= quantidade;
                return true;
            }
            return false;
        }

        public int ConsultarEstoque(Produto produto)
        {
            return _produtos.ContainsKey(produto.Id) ? _produtos[produto.Id] : 0;
        }

    }

}