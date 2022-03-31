using pastel_app.interfaces;

namespace pastel_app.domains {

    class Pedido : IPedido
    {
        public IPessoa Cliente { get; private set; }
        public IProduto Produto { get; private set; }
        public double Valor { get; private set; }
        public bool TemAcompanhamento { get; private set; }
        public Pedido(IPessoa cliente, IProduto produto)
        {
            this.Cliente = cliente;
            this.Produto = produto;

            DefinePadrao();
        }

        public Pedido(IPessoa cliente, IProduto produto, bool temAcompanhamento)
        {
            this.Cliente = cliente;
            this.Produto = produto;
            this.TemAcompanhamento = temAcompanhamento;

            DefinePadrao();
        }

        void DefinePadrao() {
            if(string.IsNullOrEmpty(this.Produto.Sabor))
                this.Produto.EscolheSaborPadrao();
        }

        public void RegistraValor(double valor) {
            this.Valor = valor;
        }
    }
}