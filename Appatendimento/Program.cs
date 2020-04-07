using System;
using System.IO;
namespace Appatendimento
{
    public class Program
    {


        // MENU

        static int Menu()
        {
            int opcao = 0;
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine(" 1 - Enfileirar cliente");
            Console.WriteLine(" 2 - Desenfileirar cliente");
            Console.WriteLine(" 3 - Obter primeiro cliente");
            Console.WriteLine(" 4 - Número total de clientes");
            Console.WriteLine(" 5 - Imprimir");
            Console.WriteLine(" 6 - Dividir");
            Console.WriteLine(" 7 - Verificar se existe cliente");
            Console.WriteLine(" 8 - Obter número de clientes à frente");
            Console.WriteLine(" 9 - Copiar");
            Console.WriteLine("10 - Obter tempo médio de espera");
            Console.WriteLine("11 - Sair");
            Console.WriteLine();
            Console.Write("Opção: ");
            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }
        static void CarregarDados(string nomeArq, FilaCliente filaCliente)
        {
            string[] lines = File.ReadAllLines(nomeArq);

            foreach (string line in lines)
            {

                String[] detalhes = line.Split(";");

                string cpf = detalhes[0];
                string nome = detalhes[1];
                int ta = Int32.Parse(detalhes[2]);
                int il = Int32.Parse(detalhes[3]);

                var cliente = new Cliente(cpf, nome, ta, il);

                filaCliente.Enfileirar(cliente);
            }
        }

        static void Main(string[] args)
        {
            var filaCliente = new FilaCliente();

            string nomeArq = (@"C:\Users\DANI\source\repos\Appatendimento\Appatendimento\bin\ClienteAtendimento.txt");

            CarregarDados(nomeArq, filaCliente);

            filaCliente.Imprimir();



            FilaCliente fila = new FilaCliente();
            int opcao;

            do
            {
                opcao = Menu();

                switch (opcao)
                {
                    case 1:
                        Console.Clear();

                        //Console.Write("Digite o nome do cliente: ");
                        //string nome = Console.ReadLine();
                        //DateTime horarioChegada = DateTime.Now;

                        Cliente cliente = new Cliente(cpf,nome,tempo_de_Atendimento_previsto,intervalor_de_leitura_seguir);
                        CarregarDados(nomeArq, filaCliente);

                        filaCliente.Imprimir();
                        break;
                    case 2:
                        Console.Clear();
                        cliente = fila.Desenfileirar();
                        if (cliente != null)
                        {
                            Console.WriteLine("O cliente {0}, saiu da fila do atemdimento!", cliente.Nome);
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("A Fila de Clientes do atemdimento está vazia! \n\n tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        cliente = fila.ObterPrimeiro();
                        if (cliente != null)
                        {
                            Console.WriteLine("O 1º Cliente da fila do atemdimento é: {0}.", cliente.Nome);
                            Console.WriteLine("Tempo de Atendimento previsto {0}.", cliente.Tempo_de_Atendimento_previsto);
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine("A Fila de Clientes do atemdimento está vazia! \n\n tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        break;
                    case 4:
                        Console.Clear();
                        int count = fila.ObterNumeroClientes();
                        Console.WriteLine("O número total de clientes no atemdimento é de: " + count);
                        Console.WriteLine("tecle ENTER para continuar...");
                        Console.ReadLine();

                        break;
                    case 5:
                        Console.Clear();
                        fila.Imprimir();
                        break;
                    case 6:
                        Console.Clear();
                        //fila.Dividir();
                        Console.WriteLine("tecle ENTER para continuar...");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        Console.Write("Informe o nome do cliente: ");
                        nome = Console.ReadLine();
                        if (fila.VerificarExistencia(nome))
                        {
                            Console.WriteLine("O Cliente pesquisado está na fila do atemdimento !");
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("O Cliente pesquisado não foi encontrado na fila do atemdimento !");
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        break;
                    case 8:
                        Console.Clear();
                        Console.Write("Informe o nome do cliente: ");
                        string nomeCliente = Console.ReadLine();
                        count = fila.ObterNumClientesAFrente(nomeCliente);
                        if (count != -1)
                        {
                            Console.WriteLine("O número de clientes à frente do " + nomeCliente + " é de: " + count);
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();

                        }
                        else
                        {
                            Console.WriteLine("O Cliente pesquisado não foi encontrado na fila do atemdimento !");
                            Console.WriteLine("tecle ENTER para continuar...");
                            Console.ReadLine();
                        }
                        break;
                    case 9:
                        Console.Clear();
                        FilaCliente copia = fila.Copiar();
                        fila.ImprimirCopia(copia);
                        break;
                    case 10:
                        Console.Clear();
                        break;
                    case 11:
                        Console.Clear();
                        Console.WriteLine("Saindo do sistema! tecle ENTER para finalizar...");
                        Console.ReadLine();
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida! tecle ENTER para continuar...");
                        Console.ReadLine();
                        break;

                }
            } while (opcao != 11);
        }
    }
}



