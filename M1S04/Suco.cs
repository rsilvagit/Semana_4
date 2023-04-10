using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1S04
{
    public class Suco : Bebida
    {
        public string TipoDeCaixa { get; set; }

        public Suco(int id, string nome, decimal miliLitro, decimal valorCompra, string tipoDeCaixa) : base(id, nome, miliLitro, valorCompra)
        {          
            this.TipoDeCaixa = tipoDeCaixa;
        }

        public override void ImprimirDados(){
            Console.WriteLine($" Descrição: O produto id {this.Id} é um suco é do tipo {this.TipoDeCaixa} com quantidade de MiliLitros {this.MiliLitro}");            
        }
    }
}