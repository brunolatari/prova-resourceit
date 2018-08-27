using LumenWorks.Framework.IO.Csv;
using ResourceIT.Prova.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceIT.Prova.JobImportExcel
{
    public class ImportExcel
    {
        public IEnumerable<DadosMercado> ImportarDadosMercado()
        {
            DadosMercado dadosMercado;
            List<DadosMercado> listDadosMercado = new List<DadosMercado>();
            using (CsvReader csv = new CsvReader(new StreamReader(ConfigurationManager.AppSettings["pathFile"]), true))
            {
                //  string[] headers = csv.GetFieldHeaders();
                while (csv.ReadNextRecord())
                {
                    for (int i = 0; i < csv.FieldCount; i++)
                    {
                        var valorSeparado = csv[i].Split(';');
                        dadosMercado = new DadosMercado()
                        {
                            ID_PRECO = Convert.ToInt32(valorSeparado[0]),
                            NU_PRAZO_DIAS_CORRIDOS = Convert.ToInt32(valorSeparado[1]),
                            VL_PRECO = Convert.ToInt32(valorSeparado[2])
                        };
                        //  Console.Write(string.Format("{0} = {1};", headers[i], csv[i]));
                        listDadosMercado.Add(dadosMercado);
                    }
                }
            }
            return listDadosMercado.ToList();
        }

        public IEnumerable<Operacoes> ImportarOperacoes()
        {
            Operacoes operacoes; ;
            List<Operacoes> listaOperacoes = new List<Operacoes>();
            bool primeiraLinha = true;
            using (var reader = new StreamReader(ConfigurationManager.AppSettings["pathFile2"]))
            {
                while (!reader.EndOfStream)
                {
                    var valorSeparado = reader.ReadLine().Split(';');
                    if (valorSeparado[0].Contains("CD_OPERACAO"))
                        primeiraLinha = true;
                    else
                    {
                        primeiraLinha = false;
                        operacoes = new Operacoes()
                        {
                            CD_OPERACAO = Convert.ToInt64(valorSeparado[0]),
                            DT_INICIO = valorSeparado[1],
                            DT_FIM = valorSeparado[2],
                            NM_EMPRESA = valorSeparado[3],
                            NM_MESA = valorSeparado[4],
                            NM_ESTRATEGIA = valorSeparado[5],
                            NM_CENTRALIZADOR = valorSeparado[6],
                            NM_GESTOR = valorSeparado[7],
                            NM_SUBGESTOR = valorSeparado[8],
                            NM_SUBPRODUTO = valorSeparado[9],
                            NM_CARACTERISTICA = valorSeparado[10],
                            CD_ATIVO_OBJETO = valorSeparado[11],
                            QUANTIDADE = decimal.Parse(valorSeparado[12], System.Globalization.NumberStyles.Float),
                            ID_PRECO = Convert.ToInt32(valorSeparado[13])
                        };
                        listaOperacoes.Add(operacoes);
                    }
                }
            }
            return listaOperacoes.ToList();
        }
    }
}
