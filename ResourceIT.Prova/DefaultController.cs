
using ClosedXML.Excel;
using ResourceIT.Prova.Entities;
using ResourceIT.Prova.JobImportExcel;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web.Http;

namespace ResourceIT.ProvaCSharp
{
    [AllowAnonymous]
    [RoutePrefix("api/resourceIT")]
    public class DefaultController : ApiController
    {        
        [HttpGet]
        [Route("excel")]
        public HttpResponseMessage GetExcel()
        {
            var horaInicio = DateTime.Now;
            Console.WriteLine("\nO processo foi iniciado...");
            Console.WriteLine("Hora Inicio: " + horaInicio);

            var watch = System.Diagnostics.Stopwatch.StartNew();

            ImportExcel import = new ImportExcel();

            List<DadosMercado> listImportDadosMercado = new List<DadosMercado>();

            Console.WriteLine("\nImportando Dados do Mercado...\n");
            listImportDadosMercado = import.ImportarDadosMercado().ToList();

            List<Operacoes> listImportOperacoes = new List<Operacoes>();

            Console.WriteLine("Importando Operações...\n");
            listImportOperacoes = import.ImportarOperacoes().ToList();

            var resultado = new Resultado();

            Console.WriteLine("Fazendo a lógica solicitada...\n");
            var resultadoOperacao = resultado.ResultadoOperacao(listImportDadosMercado, listImportOperacoes);

            watch.Stop();
            var tempo = watch.Elapsed.TotalMinutes;

            Console.WriteLine("O Excel foi gerado!\n\n");


            var horaFim = DateTime.Now;
            Console.WriteLine("Hora Fim: " + horaFim);

            TimeSpan diferencaSegundos = horaFim.Subtract(horaInicio);
            Console.WriteLine("Tempo de execução: " + diferencaSegundos.Seconds.ToString("F2", CultureInfo.InvariantCulture));

            Console.WriteLine("\n\n\nPressione qualquer tecla para fechar o Console...");

            var memory = new Excel().GenerateExcel(resultadoOperacao);
            return ControllerUtils.Ok(memory, "resourceIt.csv");

        }
    }
}
