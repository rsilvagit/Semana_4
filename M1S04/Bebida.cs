using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1S04
{
    public class Bebida
    {
        public int Id { get; set; }
        public string? Tipo { get; set; }
        public decimal MiliLitro { get; set; }
        public string? NomeBebida { get; set; }
        public decimal ValorCompra { get; set; }    

        public Bebida(int id, string nome, decimal miliLitro, decimal valorCompra) 
        {
            this.Id = id;
            this.NomeBebida = nome;
            this.MiliLitro = miliLitro;
            this.ValorCompra = valorCompra;   
        }

        public void Comprar(){            
            Console.WriteLine($"Valor da compra do produto id {Id} alterado para {ValorCompra}");
        }

        public virtual void ImprimirDados(){
            Console.WriteLine($" Descrição: O produto id {this.Id} é uma bebida com quantidade de MiliLitros {this.MiliLitro}");            
        }
    }
}