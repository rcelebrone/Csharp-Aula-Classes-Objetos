
using pastel_app.interfaces;

namespace pastel_app.domains {

    class Bebida : IBebida
    {
        public string Sabor { get; set; }
        public int Tamanho { get; private set; }

        public Bebida(string sabor, int tamanho)
        {
            this.Sabor = sabor;
            this.Tamanho = tamanho;
        }

        public void EscolheSaborPadrao()
        {
            this.Sabor = "Laranja";
        }
    }
}