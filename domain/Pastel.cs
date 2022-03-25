namespace pastel_app.domain {

    class Pastel
    {
        public string Sabor { get; private set; }
        public int Tamanho { get; private set; }
        public bool Acompanhamento { get; set; }

        public Pastel(string sabor, int tamanho)
        {
            this.Sabor = sabor;
            this.Tamanho = tamanho;
        }
    }
}