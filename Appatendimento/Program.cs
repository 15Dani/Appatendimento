using System;
using System.Collections.Generic;
using System.IO;
namespace Appatendimento
{
    class Program
    {
        static void Main(string[] args)
        {

            //Instância da lista que será preenchida

            List<Cliente> lista = new List<Cliente>();

            //Retorna todas as linhas do arquivo em um array
            //de string, onde cada linha será um índice do array

            string[] array = File.ReadAllLines(@"C:\Users\DANI\source\repos\Appatendimento\Appatendimento\bin\ClienteAtendimento.txt");

            //percorro o array e para cada linha

            for (int i = 0; i < array.Length; i++)
            {
                //crio um objeto do tipo Cliente

                Cliente cliente = new Cliente();

                //Uso o método Split e quebro cada linha
                //em um novo array auxiliar, ou seja, cada
                //conteúdo do arquivo txt separado por '|' será
                //um nova linha neste array auxiliar. Assim sei que
                //cada índice representa uma propriedade

                string[] auxiliar = array[i].Split(';');

                //Aqui recupero os itens, atribuindo
                //os mesmo as propriedade da classe
                //Cliente correspondentes, ou seja,
                //o índice zero será corresponde ao Id
                //o um ao nome e o dois ao e-mail

                cliente.Cpf = auxiliar[0];
                cliente.Nome = auxiliar[1];
                cliente.Tempo_de_Atendimento_previsto = Convert.ToInt32(auxiliar[2]);
                cliente.Intervalor_de_leitura_seguir = Convert.ToInt32(auxiliar[3]);


                //Adiciono o objeto a lista
                lista.Add(cliente);


            }

            //Para verificar o resultado percorro a lista
            //e exibo os valores recuparados pelo List<Cliente>

            foreach (var item in lista)
            {
                Console.WriteLine(@" Cpf: {0}; Nome: {1}; Tempo_de_Atendimento_previsto: {2};  Intervalor_de_leitura_seguir:  {3} ", item.Cpf, item.Nome,  item.Tempo_de_Atendimento_previsto, item.Intervalor_de_leitura_seguir );
                Console.WriteLine("@---------------------------------------");
            }

            Console.ReadKey();




        }
    }
}
