using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
namespace Appatendimento
{
    class Program
    {
        public static void CarregarDados(String nomeArq, FilaCliente filaCliente)  Throws FileNotFoundException
        {

      

       }



     static void Main(string[] args)
     {

        Fila filaCliente = new Fila();
        final String nomeArq = "dadosAlunos.txt";

        CarregarDados(nomeArq, filaCliente);
        Console.WriteLine(filaCliente);
        Console.WriteLine("\n");
        Cliente primeiro = (Cliente)filaCliente.retirar();

        Console.WriteLine(filaCliente);






}
}


