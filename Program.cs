using static System.Console;
using System.Collections.Generic;
using System.Linq;
using pastel_app.domain;
using System;

namespace pastel_app
{
    class Program
    {

        const double PRECO_PASTEL = 2.50;

        static void Main(string[] args)
        {
            var pedidos = new List<Pedido>();
            var fatura = new Fatura();

            while (true) {

                WriteLine("|c: Novo cliente \n|Enter: Gerar fatura");

                if (ReadKey().Key == ConsoleKey.C) {
            
                    var cliente = ClienteSacaDinheiroEVaiAteAPastelaria();

                    var pedido = ClienteFazUmPedido(cliente, ref pedidos);

                    var valor = PastelariaCobraOPedido(pedido, PRECO_PASTEL);

                    PastelatiaRegistraACompra(pedido, ref fatura);

                } else if (ReadKey().Key == ConsoleKey.Enter) {

                    WriteLine("Gerando fatura.....");

                    fatura.ImprimeFatura();
                } else {
                    WriteLine("Opção não existe");
                }
            }
        }

        static void PastelatiaRegistraACompra(Pedido pedido, ref Fatura fatura)
        {
            if(fatura.Pedidos == null)
                fatura.Pedidos = new List<Pedido>();

            fatura.Pedidos.Add(pedido);
            fatura.RegistrarCobrança(pedido.Valor);
        }

        static Pessoa ClienteSacaDinheiroEVaiAteAPastelaria() {
            var nome = PegarValorDoConsole("(string) Qual o nome da pessoa? ");
            var pessoa = new Pessoa(nome);

            var dinheiro = double.Parse(PegarValorDoConsole("(double) Quer sacar quanto do banco? "));
            pessoa.AdquirirDinheiro(dinheiro);

            WriteLine("O cliente {0} sacou {1} e foi até a pastelaria", 
                pessoa.Nome, 
                pessoa.Dinheiro.ToString("C"));

            return pessoa;
        }

        static Pedido ClienteFazUmPedido(Pessoa cliente, ref List<Pedido> pedidos) {
            var sabor = PegarValorDoConsole("(string) Qual o sabor do pastel? ");
            var tamanho = int.Parse(PegarValorDoConsole("(int) Qual o tamanho do pastel? (1 | 2)"));
            var p = new Pastel(sabor, tamanho);

            var acompanhamento = bool.Parse(PegarValorDoConsole("(bool) Quer acompanhamento? (true | false) "));
            if (acompanhamento) {
                p.Acompanhamento = acompanhamento;
            }

            var pedido = new Pedido(cliente, p);

            pedidos.Add(pedido);

            WriteLine("O cliente {0} pediu um pastel de {1}", 
                cliente.Nome, 
                pedido.Pastel.Sabor);

            return pedido;
        }

        static double PastelariaCobraOPedido(Pedido pedido, double valor) {

            if (pedido.Pastel.Tamanho == 1) {
                pedido.Cliente.DeduzirDinheiro(valor);
                pedido.RegistraValor(valor);
            } else {
                pedido.Cliente.DeduzirDinheiro(valor * 2);
                pedido.RegistraValor(valor * 2);
            }

            WriteLine("O cliente {0} comprou o pastel de {1} por {2} e recebeu {3} de troco", 
                pedido.Cliente.Nome, 
                pedido.Pastel.Sabor, 
                PRECO_PASTEL.ToString("C"),
                pedido.Cliente.Dinheiro.ToString("C"));

            return pedido.Valor;
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
