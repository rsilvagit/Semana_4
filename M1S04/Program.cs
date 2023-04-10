using M1S04;

int opcaoEscolhida = 0;

while (opcaoEscolhida != 7)
{
    Menu.DisplayInicial();
    opcaoEscolhida = Menu.SelecionarOpcao();
    
    switch (opcaoEscolhida)
    {
        case 1:
            Console.WriteLine("Você escolheu 'Inserir Bebida'! Precisamos coletar algumas informações:");            
            Menu.InserirBebida();
            Menu.DisplayInicial();
            break;

        case 2:
            Console.WriteLine("Você escolheu 'Alterar Bebida'! Precisamos coletar algumas informações:");
            Menu.AlterarBebida();
            Menu.DisplayInicial();
            break;

        case 3:
            Console.WriteLine("Você escolheu 'Excluir Bebida'! Informe o Id da bebida:");
            //Menu.ExcluirBebida();
            
            Menu.DisplayInicial();
            break;

        case 4:
            Console.WriteLine("Você escolheu 'Listar todas as bebidas'!");
            Repositorio.ListarTodasBebidas();
            Menu.DisplayInicial();
            break;

        case 5:
            Console.WriteLine("Você escolheu 'Listar todos os sucos'!");
            Repositorio.ListarTodosSucos();
            Menu.DisplayInicial();
            break;

        case 6:
            Console.WriteLine("Você escolheu 'Listar todos os refrigerantes'!");
            Repositorio.ListarTodosRefrigerantes();
            Menu.DisplayInicial();
            break;
        case 7:
            Console.Write("Até logo!");            
            break;

        default:
            Console.WriteLine("Dados com erros, aguarde 3 segundos para a tela carregar o display inicial");
            Thread.Sleep(2000);
            Menu.DisplayInicial();
            break;
    }    
}