namespace pastel_app.domain {

    class Pessoa {

        public string Nome { get; private set; }
        public double Dinheiro { get; private set; }

        public Pessoa(string nome)
        {
            this.Nome = nome;
        }

        public void DeduzirDinheiro(double valor) {
            if(valor > this.Dinheiro) {
                throw new System.Exception("Não tenho dinheiro");
            } else {
                this.Dinheiro -= valor;
            }
        }

        public void AdquirirDinheiro(double valor) {
            this.Dinheiro += valor;
        }

        private void MudarNomeDaPessoa (string nome) {
            // solicitação no cartório
            // registro de alteração
            this.Nome = Nome;
        }
    }

}