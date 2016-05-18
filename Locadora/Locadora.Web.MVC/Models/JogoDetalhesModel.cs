using Locadora.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Locadora.Web.MVC.Models
{
    public class JogoDetalhesModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage ="Campo Nome obrigatório!")]
        [StringLength(150,MinimumLength =5,ErrorMessage ="O nome deve ter no mínimo 5 e no máximo 150 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo Categoria Obrigatório!")]
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Campo Descricao Obrigatória!")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Campo Selo Obrigatório")]
        public Selo Selo { get; set; }

        public string Imagem { get; set; }
        public string Video { get; set; }
    }
}