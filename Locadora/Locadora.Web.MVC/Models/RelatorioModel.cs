using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Locadora.Web.MVC.Models
{
    public class RelatorioModel
    {
        public List<JogoModel> JogosDisponiveis { get; set; }
        public List<JogoLocadoModel> JogosLocados { get; set; }
        public int QuantidadeDeJogos { get; set; }
    }
}