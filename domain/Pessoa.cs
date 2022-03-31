using System;
using pastel_app.interfaces;
using pastel_app.exceptions;

namespace pastel_app.domains {

    class Pessoa : IPessoa {

        public double Dinheiro { get; private set; }

        public string Nome { get; private set; }

        public Pessoa(string nome)
        {
            this.Nome = nome;

            AdquirirDinheiro();
        }

        public bool TemDinheiroParaPagar(double valor) {
            return this.Dinheiro > valor;
        }

        public void EfetuarUmPagamento(double valor) {
            if(valor > this.Dinheiro) {
                throw new SemDinheiroException("Não tenho dinheiro");
            } else {
                this.Dinheiro -= valor;
            }
        }

        void AdquirirDinheiro() {
            var rand = new Random();
            this.Dinheiro = rand.Next(0, 50);
        }
    }

}