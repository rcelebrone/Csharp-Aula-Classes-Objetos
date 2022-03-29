namespace pastel_app.domain {

    class Pedido
    {
        public Pessoa Cliente { get; private set; }
        public Pastel Pastel { get; private set; }
        public double Valor { get; private set; }

        public Pedido(Pessoa cliente, Pastel pastel)
        {
            this.Cliente = cliente;
            this.Pastel = pastel;
        }

        public void RegistraValor(double valor) {
            this.Valor = valor;
        }
    }
}