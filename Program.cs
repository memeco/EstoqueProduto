using System;
using System.Collections.Generic;

namespace SistemaDeProdutos
{
    class Program
    {
        static void Main()
        {
            Estoque estoque = new Estoque();
            Compras compras = new Compras(estoque);
            Vendas vendas = new Vendas(estoque);

            List<Produto> produtos = new List<Produto>();

            while (true)
            {
                Console.WriteLine("Sistema de Cadastro de Produtos");
                Console.WriteLine("1 - Cadastrar Produto");
                Console.WriteLine("2 - Comprar Produto");
                Console.WriteLine("3 - Vender Produto");
                Console.WriteLine("4 - Consultar Estoque");
                Console.WriteLine("5 - Sair");
                Console.Write("Escolha uma opção: ");

                int opcao;
                while (!int.TryParse(Console.ReadLine(), out opcao) || opcao < 1 || opcao > 5)
                {
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    Console.Write("Escolha uma opção: ");
                }

                switch (opcao)
                {
                    case 1:
                        Console.Write("Digite o ID do produto: ");
                        int idNovo;
                        while (!int.TryParse(Console.ReadLine(), out idNovo))
                        {
                            Console.WriteLine("ID inválido. Tente novamente.");
                            Console.Write("Digite o ID do produto: ");
                        }

                        Console.Write("Digite o nome do produto: ");
                        string nomeNovo = Console.ReadLine();

                        Console.Write("Digite o preço do produto: ");
                        decimal precoNovo;
                        while (!decimal.TryParse(Console.ReadLine(), out precoNovo))
                        {
                            Console.WriteLine("Preço inválido. Tente novamente.");
                            Console.Write("Digite o preço do produto: ");
                        }

                        Produto produtoNovo = new Produto(idNovo, nomeNovo, precoNovo);
                        produtos.Add(produtoNovo);
                        Console.WriteLine("Produto cadastrado com sucesso!");
                        break;

                    case 2:
                        Console.Write("Digite o ID do produto para comprar: ");
                        int idCompra;
                        while (!int.TryParse(Console.ReadLine(), out idCompra))
                        {
                            Console.WriteLine("ID inválido. Tente novamente.");
                            Console.Write("Digite o ID do produto para comprar: ");
                        }
                        Produto produtoCompra = produtos.Find(p => p.Id == idCompra);
                        if (produtoCompra != null)
                        {
                            Console.Write("Digite a quantidade a comprar: ");
                            int quantidadeCompra;
                            while (!int.TryParse(Console.ReadLine(), out quantidadeCompra))
                            {
                                Console.WriteLine("Quantidade inválida. Tente novamente.");
                                Console.Write("Digite a quantidade a comprar: ");
                            }
                            compras.ComprarProduto(produtoCompra, quantidadeCompra);
                            Console.WriteLine("Compra realizada com sucesso!");
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado.");
                        }
                        break;

                    case 3:
                        Console.Write("Digite o ID do produto para vender: ");
                        int idVenda;
                        while (!int.TryParse(Console.ReadLine(), out idVenda))
                        {
                            Console.WriteLine("ID inválido. Tente novamente.");
                            Console.Write("Digite o ID do produto para vender: ");
                        }
                        Produto produtoVenda = produtos.Find(p => p.Id == idVenda);
                        if (produtoVenda != null)
                        {
                            Console.Write("Digite a quantidade a vender: ");
                            int quantidadeVenda;
                            while (!int.TryParse(Console.ReadLine(), out quantidadeVenda))
                            {
                                Console.WriteLine("Quantidade inválida. Tente novamente.");
                                Console.Write("Digite a quantidade a vender: ");
                            }
                            bool vendaRealizada = vendas.VenderProduto(produtoVenda, quantidadeVenda);
                            if (vendaRealizada)
                            {
                                Console.WriteLine("Venda realizada com sucesso!");
                            }
                            else
                            {
                                Console.WriteLine("Estoque insuficiente.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Produto não encontrado.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Estoque de Produtos:");
                        foreach (var produto in produtos)
                        {
                            int quantidade = estoque.ConsultarEstoque(produto);
                            Console.WriteLine($"ID: {produto.Id}, Nome: {produto.Nome}, Estoque: {quantidade}");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Saindo do programa...");
                        return;

                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }

                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
