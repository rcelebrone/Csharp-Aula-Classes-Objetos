using static System.Console;
using System;
using System.Collections.Generic;
using pastel_app.domains;
using pastel_app.interfaces;
using pastel_app.exceptions;

namespace pastel_app
{
    class Program
    {

        const double PRECO_PASTEL = 2.50;

        enum TIPO_PRODUTO {
            BEBIDA,
            PASTEL
        }

        static void Main(string[] args)
        {
            var pedidos = new List<IPedido>();

            while (true) {

                WriteLine("|c: Novo cliente \n|Enter: Gerar fatura");

                if (ReadKey().Key == ConsoleKey.C) {
                    
                    IPessoa cliente;
                    try {
                        cliente = GerarCliente(PRECO_PASTEL);
                    } catch (SemDinheiroException) {
                        continue;
                    }

                    WriteLine("------------------------------------");

                    var pedido = ReceberPedido(cliente, ref pedidos);

                    CobrarPedido(pedido, PRECO_PASTEL);

                } else if (ReadKey().Key == ConsoleKey.F) {

                    WriteLine("Gerando fatura.....");

                    var fatura = new Fatura(pedidos);

                    fatura.ImprimeFatura();
                } else {
                    WriteLine("Opção não existe");
                }
            }
        }

        static IPessoa GerarCliente(double produto_menor_preco) {
            var nome = PegarValorDoConsole("(string) Qual o nome do cliente? ");
            var pessoa = new Pessoa(nome);

            if (!pessoa.TemDinheiroParaPagar(produto_menor_preco)) {
                string msg = string.Format("O cliente {0} não tem dinheiro suficiente para comprar nessa pastelaria e foi embora", 
                    pessoa.Nome);

                WriteLine(msg);

                throw new SemDinheiroException(msg);
            } else 
                WriteLine("O cliente {0} entrou na pastelaria", 
                    pessoa.Nome);

            return pessoa;
        }

        static IPedido ReceberPedido(IPessoa cliente, ref List<IPedido> pedidos) {
            var tipo = PegarValorDoConsole("Quer pedir um pastel ou uma bebida? (1 = Pastel | 2 = Bebida)");
            var sabor = PegarValorDoConsole("Qual o sabor da bebida? (escreva o nome)");
            var tamanho = int.Parse(PegarValorDoConsole("Qual o tamanho da bebida? (1 = pequena | 2 = grande)"));
            var acompanhamento = bool.Parse(PegarValorDoConsole("Quer acompanhamento? (true | false) "));
            
            IProduto produto;
            IPedido pedido;

            switch(int.Parse(tipo)) {
                case 2 : {
                    produto = new Bebida(sabor, tamanho);
                    break;
                }
                case 1 : {
                    produto = new Pastel(sabor, tamanho);
                    break;
                }
                default: {
                    throw new ProdutoInexistenteException(string.Format("O tipo {} não é uma opção valida", tipo));
                }
            }

            if (!acompanhamento) 
                pedido = new Pedido(cliente, produto);
            else 
                pedido = new Pedido(cliente, produto, acompanhamento);

            pedidos.Add(pedido);

            WriteLine("O cliente {0} pediu uma bebida de {1} {2}", 
                cliente.Nome, 
                pedido.Produto.Sabor,
                pedido.TemAcompanhamento ? "e tem acompanhamento" : " e não tem acompanhamento");

            return pedido;
        }

        static void CobrarPedido(IPedido pedido, double valor) {

            if (pedido.Produto.Tamanho == 1) {
                pedido.Cliente.EfetuarUmPagamento(valor);
                pedido.RegistraValor(valor);
            } else {
                if (pedido.Cliente.TemDinheiroParaPagar(valor))
                pedido.Cliente.EfetuarUmPagamento(valor * 2);
                pedido.RegistraValor(valor * 2);
            }

            WriteLine("O cliente {0} comprou o pastel de {1} por {2} e recebeu {3} de troco", 
                pedido.Cliente.Nome, 
                pedido.Produto.Sabor, 
                PRECO_PASTEL.ToString("C"),
                pedido.Cliente.Dinheiro.ToString("C"));
        }

        static string PegarValorDoConsole(string mensagem) {
            WriteLine(mensagem);
            
            try {
                return ReadLine();
            } catch {
                return null;
            }
        }
    }
}
