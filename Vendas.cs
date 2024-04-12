namespace SistemaDeProdutos
{
    public class Vendas
    {
        private Estoque _estoque;

        public Vendas(Estoque estoque)
        {
            _estoque = estoque;
        }

        public bool VenderProduto(Produto produto, int quantidade)
        {
            return _estoque.RemoverProduto(produto, quantidade);
        }
    }
}