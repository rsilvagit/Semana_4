using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1S04
{
    public class Refrigerante : Bebida
    {
        public bool Vidro { get; set; }

        public Refrigerante(int id, string nome, decimal miliLitro, decimal valorCompra, bool vidro) : base(id, nome, miliLitro, valorCompra)
        {          
            this.Vidro = vidro;
        }

        public override void ImprimirDados(){
            Console.WriteLine($" Descrição: O produto id {this.Id} com nome {this.NomeBebida} é um refrigerante MiliLitros {this.MiliLitro} {(this.Vidro==true ? "e um vidro" : "e uma garrafa pet")}");            
        }
    }
}