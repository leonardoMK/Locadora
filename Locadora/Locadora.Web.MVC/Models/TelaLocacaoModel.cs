using Locadora.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Web.MVC.Models
{
    public class TelaLocacaoModel
    {
        public int Id { get; set; }
        public string NomeJogo { get; set; }
        public Selo Selo { get; set; }
        public string Imagem { get; set; }
        public string DataPrevista { get; set; }
        public string ValorDaLocacao { get; set; }
    }
}
