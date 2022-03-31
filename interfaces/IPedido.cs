namespace pastel_app.interfaces {

    interface IPedido
    {
        IPessoa Cliente { get; }
        IProduto Produto { get; }
        bool TemAcompanhamento { get; }
        double Valor { get; }
        void RegistraValor(double valor);
    }
}