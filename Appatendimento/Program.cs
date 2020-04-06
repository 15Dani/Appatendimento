using System;
using System.IO;
namespace Appatendimento
{
    public class Program {
        static void CarregarDados(string nomeArq, FilaCliente filaCliente)                                         
        {
            // Abre o arquivo.
            string[] lines = File.ReadAllLines(nomeArq);

            // Percorre todas as linhas do arquivo.
            foreach (string line in lines)
            {
                // Qubra a linha pelo caracter coringa ";".
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
        }
            
        
    }
}