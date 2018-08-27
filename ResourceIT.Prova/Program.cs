using Microsoft.Owin.Hosting;
using System;
using System.Configuration;

namespace ResourceIT.ProvaCSharp
{
    class Program
    {
        static string _baseAddress { get { return ConfigurationManager.AppSettings["BASE_ADDRESS"]; } }

        static void Main(string[] args)
        {
            using (WebApp.Start<Startup>(_baseAddress))
            {
                Console.WriteLine("Api Inicializada. Caminho: " + _baseAddress);
                Console.WriteLine("\nPara iniciar o processo, digite a API no Browser>: " + _baseAddress + "api/resourceIT/excel");
                Console.WriteLine("\nApós digitar a API no Browser, volte para o Console para ver o tempo total do processamento...");
                Console.WriteLine("heya");
                Console.ReadLine();
            }
        }
    }
}
