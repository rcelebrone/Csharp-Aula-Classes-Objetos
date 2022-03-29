using System;
using System.Linq;
using System.Collections.Generic;

namespace pastel_app.domain {

    class Fatura
    {
        public double Total { get; set; }

        public List<Pedido> Pedidos { get; set; }

        public void RegistrarCobrança(double preço) {
            this.Total += preço;
        }

        public void ImprimeFatura() {
            Console.WriteLine(
                "---------------------\n"+
                "Total de pedidos: {0}\n"+
                "Sabores vendidos: {1}\n"+
                "Total faturado: {2}\n"+ 
                "---------------------\n",
                Pedidos.Count, 
                EscreveDetalhesDosPedidosParaImpressão(), 
                this.Total);
        }

        string EscreveDetalhesDosPedidosParaImpressão() {

            string sabores = null;

            this.Pedidos
                .Select(p => p.Pastel)
                .GroupBy(p => p.Sabor.ToLower())
                .ToList()
                .ForEach(s => {
                    sabores += s.Key + ", ";
            });

            return sabores.Substring(0, sabores.Length - 2);
        }
    }
}