using System;
using pastel_app.domain;

namespace pastel_app
{
    class Program
    {

        const double PRECO_PASTEL = 2.50;

        static void Main(string[] args)
        {
            /*
                - precisa existir uma pessoa com nome
                - Uma pessoa adquire dinheiro
                - Uma pessoa escolhe um pastel
                - Uma pessoa paga o pastel
                - O pastel é preparado
                - A pessoa recebeu o pastel
            */

            var pessoa = PessoaComDinheiroChegaNaPastelaria();

            Console.WriteLine("A pessoa {0} vai até a pastelaria", pessoa.Nome);

            var pastel = ReceberSolicitacaoDePastel();

            CobrarCliente(pessoa, PRECO_PASTEL);
            
            Console.WriteLine("O cliente {0} comprou o pastel de {1} por {2}", pessoa.Nome, pastel.Sabor, PRECO_PASTEL.ToString("C"));
        }

        static Pessoa PessoaComDinheiroChegaNaPastelaria() {
            var nome = PegarValorDoConsole("(string) Qual o nome da pessoa? ");
            var pessoa = new Pessoa(nome);

            var dinheiro = double.Parse(PegarValorDoConsole("(double) Quer sacar quanto do banco? "));
            pessoa.AdquirirDinheiro(dinheiro);

            return pessoa;
        }

        static Pastel ReceberSolicitacaoDePastel() {
            var sabor = PegarValorDoConsole("(string) Qual o sabor do pastel? ");
            var tamanho = int.Parse(PegarValorDoConsole("(int) Qual o tamanho do pastel? (1 | 2)"));
            var p = new Pastel(sabor, tamanho);

            var acompanhamento = bool.Parse(PegarValorDoConsole("(bool) Quer acompanhamento? (true | false) "));
            if (acompanhamento) {
                p.Acompanhamento = acompanhamento;
            }

            return p;
        }

        static void CobrarCliente(Pessoa pessoa, double valor) {
            pessoa.DeduzirDinheiro(valor);
        }

        static string PegarValorDoConsole(string mensagem) {
            Console.WriteLine(mensagem);
            
            try {
                return Console.ReadLine();
            } catch {
                return null;
            }
        }
    }
}
