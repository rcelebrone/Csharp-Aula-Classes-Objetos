
using pastel_app.interfaces;

namespace pastel_app.domains {

    class Pastel : IPastel
    {
        public string Sabor { get; set; }
        public int Tamanho { get; private set; }

        public Pastel(string sabor, int tamanho)
        {
            this.Sabor = sabor;
            this.Tamanho = tamanho;
        }

        public void EscolheSaborPadrao()
        {
            this.Sabor = "Carne";
        }
    }
}