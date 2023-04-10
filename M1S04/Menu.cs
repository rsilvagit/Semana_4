using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M1S04
{
    /// <summary>
    /// CLasse statica para criação do menu
    /// </summary>
    public static class Menu
    {
        private static List<Bebida> ListaDeBebidas { get; set; }
        private static string? opcao;

        static Menu()
        {
            ListaDeBebidas = new List<Bebida>();
        }

        /// <summary>
        /// Display inicial
        /// </summary>
        public static void DisplayInicial()
        {
            Console.Clear();
            Console.WriteLine("Bem-vindo ao GoDrink! O que você deseja fazer?");
            Console.WriteLine("1 - Inserir Bebida");
            Console.WriteLine("2 - Alterar Bebida");
            Console.WriteLine("3 - Excluir Bebida");
            Console.WriteLine("4 - Listar todas as bebidas");
            Console.WriteLine("5 - Listar todos os sucos");
            Console.WriteLine("6 - Listar todos os refrigerantes");
            Console.WriteLine("7 - Sair");
        }
     
        /// <summary>
        /// Inserir uma bebida
        /// </summary>
        /// <returns></returns>
        public static void InserirBebida()
        {
            try
            {       
                int tipo = 0;
                bool vidro = false;
                string tipoDeCaixa = "";
                string? nome = "";

                do {
                    Console.Write("Informe o tipo da bebida: (1-Refrigerante ou 2-Suco)\n");
                    opcao = Console.ReadLine();
                } while(!TipoBebidaValido(opcao)); 
                tipo = int.Parse(opcao);

                Console.Write("Informe o nome da bebida:\n");
                nome = Console.ReadLine();

                Console.Write("Informe a quantidade de ml da bebida:\n");
                decimal miliLitro = decimal.Parse(Console.ReadLine());
                
                Console.Write("Informe o valor de compra da bebida:\n");
                decimal valorCompra = decimal.Parse(Console.ReadLine());

                switch (tipo)
                {
                    case 1:
                        do {
                            Console.Write("A garrafa é de vidro? (Informe S-Sim ou N-Não)\n");
                            opcao = Console.ReadLine();
                        } while(!(opcao.ToUpper() == "S" || opcao.ToUpper() == "N"));                 
                        
                        if(opcao=="S")
                            vidro = true;

                        Refrigerante refrigerante = new Refrigerante(Repositorio.QuantidadeBebidas() + 1, nome, miliLitro, valorCompra, vidro);
                        Repositorio.AdicionarRefrigerante(refrigerante);
                    break;

                    case 2:
                        Console.Write("Informe o tipo de caixa:\n");
                        tipoDeCaixa = Console.ReadLine();

                        Suco suco = new Suco(Repositorio.QuantidadeBebidas() + 1, nome, miliLitro, valorCompra, tipoDeCaixa);
                        Repositorio.AdicionarSuco(suco);
                    break;
                }

                Console.WriteLine("Bebida cadastrada com sucesso! Aguarde a tela carregar o display inicial");
                Thread.Sleep(3000);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Falha no preenchimentos dos dados ao inserir a bebida! Aguarde a tela carregar o display inicial");
                Thread.Sleep(3000);
            }
        }

/// <summary>
        /// Inserir uma bebida
        /// </summary>
        /// <returns></returns>
        public static void AlterarBebida()
        {
            try
            {                       
                int id = 0;
                do {
                    Console.Write("Selecione qual bebida deseja alterar, informando o seu Id:\n");
                    Repositorio.ListarTodasBebidas();
                    opcao = Console.ReadLine();
                } while(!ValorNumerico(opcao));                 
                id = int.Parse(opcao);

                Bebida? bebidaAlterar = Repositorio.BuscarBebida(id);
                if(bebidaAlterar == null){
                    Console.Write("O Id informado para a bebida não existe! Aguarde 5 segundos para a tela carregar o display inicial\n");
                    Thread.Sleep(5000);
                    return;
                }

                Console.Write("Informe o nome da bebida:\n");
                var nome = Console.ReadLine();

                Console.Write("Informe a quantidade de ml da bebida:\n");
                decimal miliLitro = decimal.Parse(Console.ReadLine());
                
                Console.Write("Informe o valor de compra da bebida:\n");
                decimal valorCompra = decimal.Parse(Console.ReadLine());

                bebidaAlterar.NomeBebida = nome;
                bebidaAlterar.MiliLitro = miliLitro;
                bebidaAlterar.ValorCompra = valorCompra;

                Repositorio.AlterarBebida(bebidaAlterar);

                Console.WriteLine("Bebida alterada com sucesso! Aguarde 5 segundos para a tela carregar o display inicial");
                Thread.Sleep(5000);
            }
            catch (System.Exception)
            {
                Console.WriteLine("Falha no preenchimentos dos dados ao editar a bebida! Aguarde 5 segundos para a tela carregar o display inicial");
                Thread.Sleep(5000);
            }
        }


        /// <summary>
        /// Opção selecionada
        /// </summary>
        /// <returns></returns>
        public static int SelecionarOpcao()
        {
            do {
                Console.WriteLine("Selecione uma opção do menu: ");
                opcao = Console.ReadLine();
            } while(!ItemMenuValido(opcao));
            
            return Convert.ToInt32(opcao);
        }

        private static bool ItemMenuValido(string? readLine){
            try
            {
                if(readLine == null)
                    return false;
                    
                var resultado = int.Parse(readLine); 
                
                if(resultado < 0 || resultado > 7){
                    Console.WriteLine("A opção informada não existe! Vamos tentar novamente.");
                    return false;
                }

                return true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Opção inválida! Você deve preencher somente números.");
                return false;
            }
        }

        private static bool TipoBebidaValido(string? readLine){
            try
            {
                if(readLine == null)
                    return false;
                    
                var resultado = int.Parse(readLine); 
                
                if(resultado != 1 && resultado != 2){
                    Console.WriteLine("A opção informada não existe! Vamos tentar novamente.");
                    return false;
                }

                return true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Opção inválida! Você deve preencher somente números.");
                return false;
            }
        }

        private static bool ValorNumerico(string? readLine){
            try
            {
                if(readLine == null)
                    return false;
                    
                var resultado = int.Parse(readLine); 
                
                return true;
            }
            catch (System.Exception)
            {
                Console.WriteLine("Opção inválida! Você deve preencher somente números.");
                return false;
            }
        }
    }
}