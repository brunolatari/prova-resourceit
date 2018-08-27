using System.Collections.Generic;
using System.Linq;

namespace ResourceIT.Prova.Entities
{
    public class Resultado
    {
        public int ID_PRECO { get; set; }
        public decimal QUANTIDADE { get; set; }
        public int VL_PRECO { get; set; }
        public string NM_SUBPRODUTO { get; set; }
        public decimal RESULTADO { get; set; }


        public IEnumerable<Resultado> ResultadoOperacao(List<DadosMercado> listDadosMercado, List<Operacoes> listOperacoes)
        {
            //var listaDadosMercado = new List<DadosMercado>();
            //var listaOperacoes = new List<Operacoes>();

            //listaDadosMercado.AddRange(listDadosMercado);
            //listaOperacoes.AddRange(listOperacoes);
            List<Resultado> resultado = new List<Resultado>();
            var ola = "";

            var listOperacoesComGroupBy =
                (from A in listOperacoes
                 group A by new { A.NM_SUBPRODUTO, A.ID_PRECO } into C
                 select new
                 {
                     ID_PRECO = C.Key.ID_PRECO,
                     NM_SUBPRODUTO = C.Key.NM_SUBPRODUTO,
                     QUANTIDADE = C.Sum(A => A.QUANTIDADE)
                 }).ToList();

            var listOperacoesDadosMercadoComGroupBy =
                (from A in listOperacoesComGroupBy
                 join B in listDadosMercado on A.ID_PRECO equals B.ID_PRECO
                 group B by new { A.ID_PRECO, A.NM_SUBPRODUTO, A.QUANTIDADE } into C
                 select new
                 {
                     ID_PRECO = C.Key.ID_PRECO,
                     NM_SUBPRODUTO = C.Key.NM_SUBPRODUTO,
                     QUANTIDADE = C.Key.QUANTIDADE,
                     VL_PRECO = C.Sum(B => B.VL_PRECO)
                 }).ToList();

            var result =
                (from A in listOperacoesDadosMercadoComGroupBy
                 group A by new { A.NM_SUBPRODUTO } into B
                 select new
                 {
                     NM_SUBPRODUTO = B.Key.NM_SUBPRODUTO,
                     QUANTIDADE = B.Sum(A => A.QUANTIDADE),
                     VL_PRECO = B.Sum(A => A.VL_PRECO)
                 }).ToList();

            result.ForEach(x => resultado.Add(
                new Resultado()
                {
                    NM_SUBPRODUTO = x.NM_SUBPRODUTO,
                    RESULTADO = (x.VL_PRECO * x.QUANTIDADE)
                }));
            return resultado;


        }
    }
}
