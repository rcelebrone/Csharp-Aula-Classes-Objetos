namespace pastel_app.interfaces {

    interface IPessoa
    {
        string Nome { get; }
        double Dinheiro { get; }

        void EfetuarUmPagamento(double valor);
        bool TemDinheiroParaPagar(double valor);
    }
}