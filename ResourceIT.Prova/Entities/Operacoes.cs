using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResourceIT.Prova.Entities
{
    public class Operacoes
    {
        public long CD_OPERACAO { get; set; }
        public string DT_INICIO { get; set; }
        public string DT_FIM { get; set; }
        public string NM_EMPRESA { get; set; }
        public string NM_MESA { get; set; }
        public string NM_ESTRATEGIA { get; set; }
        public string NM_CENTRALIZADOR { get; set; }
        public string NM_GESTOR { get; set; }
        public string NM_SUBGESTOR { get; set; }
        public string NM_SUBPRODUTO { get; set; }
        public string NM_CARACTERISTICA { get; set; }
        public string CD_ATIVO_OBJETO { get; set; }
        public decimal QUANTIDADE { get; set; }
        public int ID_PRECO { get; set; }

    }
}
