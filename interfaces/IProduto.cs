namespace pastel_app.interfaces {

    interface IProduto
    {
        string Sabor { get; set; }
        int Tamanho { get; }

        enum TIPO {
            PASTEL,
            BEBIDA
        }

        void EscolheSaborPadrao();
    }
}