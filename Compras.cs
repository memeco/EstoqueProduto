namespace SistemaDeProdutos
{
    public class Compras
    {
        private Estoque _estoque;

        public Compras(Estoque estoque)
        {
            _estoque = estoque;
        }

        public void ComprarProduto(Produto produto, int quantidade)
        {
            _estoque.AdicionarProduto(produto, quantidade);
        }
    }
}