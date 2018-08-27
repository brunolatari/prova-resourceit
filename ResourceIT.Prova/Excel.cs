using ClosedXML.Excel;
using ResourceIT.Prova.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ResourceIT.ProvaCSharp
{
    public class Excel
    {

        public MemoryStream GenerateExcel(IEnumerable<Resultado> resultados)
        {
            XLWorkbook xls = new XLWorkbook();
            
            var worksheet = xls.Worksheets.Add("ResourceITProva");

            worksheet.Cell(1, 1).Value = "NM_SUBPRODUTO";
            worksheet.Cell(1, 2).Value = "RESULTADO";

            int linha = 2;
            foreach (var item in resultados)
            {
                worksheet.Cell(linha, 1).Value = item.NM_SUBPRODUTO;
                worksheet.Cell(linha, 2).Value = item.RESULTADO;

                linha++;
            }
            MemoryStream m = new MemoryStream();
            xls.SaveAs(m);
            return m;
        }
    }
}
