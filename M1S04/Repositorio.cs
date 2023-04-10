using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1S04
{
    public static class Repositorio
    {
        private static List<Bebida> Bebidas { get; set; }
        private static List<Suco> Sucos { get; set; } 
        private static List<Refrigerante> Refrigerantes { get; set; }

        static Repositorio()
        {
            if(Bebidas == null)
                Bebidas = new List<Bebida>();

            if(Sucos == null)
                Sucos = new List<Suco>();

            if(Refrigerantes == null)
                Refrigerantes = new List<Refrigerante>();
        }
        public static void AdicionarSuco(Suco suco){
            Sucos.Add(suco);
            AdicionarBebida(suco);
        }

        public static void AdicionarRefrigerante(Refrigerante refrigerante){
            Refrigerantes.Add(refrigerante);
            AdicionarBebida(refrigerante);
        }

        private static void AdicionarBebida(Bebida bebida){
            Bebidas.Add(bebida);
        }
        
        public static void AlterarBebida(Bebida bebida){
            foreach (Bebida item in Bebidas.Where(w => w.Id == bebida.Id))
            {
                item.NomeBebida = bebida.NomeBebida;
                item.Tipo = bebida.Tipo;
                item.MiliLitro = bebida.MiliLitro;
            }
        }

        public static void ExcluirBebida(int id){
            try
            {
                Bebida? bebida = Bebidas.Find(x => x.Id == id);
                if(bebida != null){
                    Bebidas.Remove(bebida);
                }                    
            }
            catch (System.Exception)
            {                
                throw;
            }            
        }
        
        public static void ListarTodasBebidas(){
            try
            {
                Console.WriteLine($"Listando as bebidas:");
                foreach (Bebida bebida in Bebidas)
                {
                    Console.WriteLine($"{bebida.Id.ToString()} - {bebida.NomeBebida} - Quantidade ml: {bebida.MiliLitro.ToString("N2")}");
                    Suco? suco = Sucos.Where(w => w.Id == bebida.Id).FirstOrDefault();
                    if(suco != null)
                        suco.ImprimirDados();

                    Refrigerante? refrigerante = Refrigerantes.Where(w => w.Id == bebida.Id).FirstOrDefault();
                    if(refrigerante != null)
                        refrigerante.ImprimirDados();
                    
                }

                Console.WriteLine("Pressione uma tecla para retornar ao menu inicial.\n");
                Console.ReadLine();
            }
            catch (System.Exception)
            {                
                throw;
            } 
        }
        
        public static void ListarTodosSucos(){
            try
            {
                Console.WriteLine($"Listando os sucos:");
                foreach (Bebida bebida in Bebidas)
                {                    
                    Suco? suco = Sucos.Where(w => w.Id == bebida.Id).FirstOrDefault();
                    if(suco != null){
                        Console.WriteLine($"{bebida.Id.ToString()} - {bebida.NomeBebida} - Quantidade ml: {bebida.MiliLitro.ToString("N2")}");
                        suco.ImprimirDados();                    
                    }
                }
                
                Console.WriteLine("Pressione uma tecla para retornar ao menu inicial.\n");
                Console.ReadLine();
            }
            catch (System.Exception)
            {                
                throw;
            } 
        }
        
        public static void ListarTodosRefrigerantes(){
            try
            {
                Console.WriteLine($"Listando os refrigerantes:");
                foreach (Bebida bebida in Bebidas)
                {
                    Refrigerante? refrigerante = Refrigerantes.Where(w => w.Id == bebida.Id).FirstOrDefault();
                    if(refrigerante != null){
                        Console.WriteLine($"{bebida.Id.ToString()} - {bebida.NomeBebida} - Quantidade ml: {bebida.MiliLitro.ToString("N2")}");
                        refrigerante.ImprimirDados();                  
                    }
                }
                
                Console.WriteLine("Pressione uma tecla para retornar ao menu inicial.\n");
                Console.ReadLine();
            }
            catch (System.Exception)
            {                
                throw;
            } 
        }

        public static Bebida? BuscarBebida(int id){            
            try
            {
                return Bebidas.Where(w => w.Id == id).FirstOrDefault();
            }
            catch (System.Exception)
            {                
                throw;
            } 
        }

        public static int QuantidadeBebidas(){
            return Bebidas.Count;
        }
    }
}