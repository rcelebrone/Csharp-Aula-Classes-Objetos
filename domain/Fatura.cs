using System;
using System.Linq;
using System.Collections.Generic;
using pastel_app.interfaces;

namespace pastel_app.domains {

    class Fatura : IFatura
    {
        double Total { get; set; }
        string Detalhes { get; set; }
        public IList<IPedido> Pedidos { get; private set; }

        public Fatura(IList<IPedido> pedidos) {
            this.Pedidos = pedidos;
            CalcularTotal();
            GerarDetalhesDaImpressão();
        }

        void CalcularTotal() {
            this.Total = this.Pedidos.Sum(p => p.Valor);
        }

        public void ImprimeFatura() {
            Console.WriteLine(
                "---------------------\n"+
                "Total de pedidos: {0}\n"+
                "Sabores vendidos: {1}\n"+
                "Total faturado: {2}\n"+ 
                "---------------------\n",
                Pedidos.Count, 
                this.Detalhes, 
                this.Total.ToString("C"));
        }

        void GerarDetalhesDaImpressão() {

            string sabores = null;

            this.Pedidos
                .Select(p => p.Produto) // IEnumerable<Pastel>
                .GroupBy(p => p.Sabor.ToLower()) // IEnumerable<IGrouping<string, Pastel>>
                .ToList() // List<IGrouping<string, Pastel>>
                .ForEach(s => {
                    sabores += s.Key + ", ";
                });

            this.Detalhes = sabores.Substring(0, sabores.Length - 2);
        }
    }
}