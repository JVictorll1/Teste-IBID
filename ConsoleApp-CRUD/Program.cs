using System.Data;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        // Aceita Caracteres UTF-8
        Console.OutputEncoding = Encoding.UTF8;
        Console.CursorVisible = false;
        
        string letraT = @"
            ############    ############    ############    ###########           
            ############    ############    ############    ############
                 ##         ##         #         ##         #         ##     
                 ##         ###########          ##         #         ## 
                 ##         ##         #         ##         #         ## 
            ############    ############    ############    ############
            ############    ############    ############    ###########
        ";

        // Mostrar Tela de Apresentação Inicial
        Console.BackgroundColor = ConsoleColor.White;
        Console.Write($"\u001b[32m{letraT}\n");
        Console.WriteLine("\u001b[35m Pressione qualquer tecla para Iniciar o Software...\u001b[0m");
        Console.ResetColor();
        Console.ReadKey();
        Console.Clear();

        //Limpar a tela do Console
        Console.Clear();
        // InstÂncia da classe Produto
        Produto p = new Produto();
        // Informações Responsáveis pelo menu de seleção e teclas
        ConsoleKeyInfo key;
        int opcao = 1;
        bool selecionado = false;
        (int left, int top) = Console.GetCursorPosition();
        string color = ">> \u001b[32m";

        // Tela principal onde toda o Front-End irá ocorrer
        while (!selecionado)
        {
            Console.SetCursorPosition(left , top);

            Console.WriteLine($"{(opcao == 1 ? color : "   ")}VISUALIZAR Lista de Produtos\u001b[0m");
            Console.WriteLine($"{(opcao == 2 ? color : "   ")}INSERIR um novo Produto\u001b[0m");
            Console.WriteLine($"{(opcao == 3 ? color : "   ")}ATUALIZAR os dados de um Produto existente\u001b[0m");
            Console.WriteLine($"{(opcao == 4 ? color : "   ")}EXCLUIR algum Produto\n\u001b[0m");
            Console.WriteLine($"{(opcao == 5 ? color : "   ")}Encerrar a execução do Software\n\u001b[0m");

            key = Console.ReadKey(true);

            switch (key.Key)
            {
                case ConsoleKey.DownArrow:
                    opcao = opcao >= 5 ? 5 : opcao + 1;
                    break;
                    
                case ConsoleKey.UpArrow:
                    opcao = opcao <= 1 ? 1 : opcao - 1;
                    break;
                
                case ConsoleKey.Enter:
                    Console.WriteLine($"Você escolheu a opção {opcao}");
                    switch (opcao)
                    {
                        case 1:
                            // ************** MOSTRAR ****************
                            Console.Clear();
                            Console.WriteLine("\u001b[33mPressioane qualquer Tecla para voltar ao Menu de Opções.\u001b[0m\n\n");
                            Console.WriteLine("\u001b[35mLISTA DE PRODUTOS\u001b[0m");
                            Console.WriteLine("................");
                            Console.WriteLine("|\u001b[36mID  |  PRODUTO\u001b[0m|");
                            Console.WriteLine("''''''''''''''''");
                            // Criação de um DataTable para receber o retorno do método 'mostrar()'
                            DataTable dadosDoProduto = p.mostrar();
                            // Loop responsável por extrair as linhas da Tabela criada no método que recebeu os valores da QUERY
                            foreach (DataRow d in dadosDoProduto.Rows)
                            {   
                                // Objeto recebe os valores da tabela para manipulação em tempo atual de execução
                                p.setId((int) d[0]);
                                p.setNome((string) d[1]);
                                // Manipulando os valores agora de forma mais flexível para Exibição no Console
                                Console.WriteLine($"|{p.getId()} - {p.getNome()}");
                            }  
                            Console.ReadKey();
                            Console.Clear();                          
                        break;

                        case 2:
                            // ************** INSERIR ***************
                            Console.Clear();
                            Console.WriteLine("\u001b[36mINSERIR PRODUTO\u001b[0m");
                            Console.WriteLine("Digite o nome do Novo Produto:");
                            Console.Write(">> ");
                            p.setNome(Console.ReadLine());
                            p.inserir(p.getNome());
                            Console.WriteLine("\u001b[31mProduto inserido com sucesso!\u001b[0m");
                            Thread.Sleep(2000);
                            Console.Clear();
                            break;
                    

                        case 3:
                            // ************** ATUALIZAR *************
                            Console.Clear();
                            Console.WriteLine("\u001b[36mATUALIZAR PRODUTO\u001b[0m");
                            Console.WriteLine("Digite o ID do Produto a ser Atualizado: ");
                            Console.Write(">> ");
                            p.setId((Convert.ToInt32(Console.ReadLine())));
                            Console.WriteLine("Digite o novo nome do Produto: ");
                            Console.Write(">> ");
                            p.setNome(Console.ReadLine());
                            p.atualizar(p.getId(), p.getNome());
                            Console.WriteLine("\u001b[31mProduto atualizado com sucesso!\u001b[0m");
                            Thread.Sleep(2000);
                            Console.Clear();
                        break;

                        case 4:
                            // ************** EXCLUIR ***************
                            Console.Clear();
                            Console.WriteLine("\u001b[36mEXCLUIR PRODUTO\u001b[0m");
                            Console.WriteLine("Digite o ID do Produto a ser Excluído: ");
                            Console.Write(">> ");
                            p.excluir(Convert.ToInt32((Console.ReadLine())));
                            Console.WriteLine("\u001b[31mProduto excluído com sucesso!\u001b[0m");
                            Thread.Sleep(2000);
                            Console.Clear();
                        break;

                        case 5:
                            Environment.Exit(0);
                        break;
                    }

                    break;
            }
        }
    }
}