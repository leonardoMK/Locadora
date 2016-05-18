using Locadora.Repositorio.EF;
using Locadora.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locadora.Web.MVC.Seguranca;
using Locadora.Dominio;

namespace Locadora.Web.MVC.Controllers
{
    [Autorizador]
    public class RelatorioController : Controller
    {
        public ActionResult JogosLocados()
        {
            var banco = new JogoRepositorio();
            var clienteRepositorio = new ClienteRepositorio();
            var jogosLocados = banco.BuscarTodos().Where(j => j.IdCliente != null).ToList();
            List<JogoLocadoModel> jogos = new List<JogoLocadoModel>();
            foreach (var j in jogosLocados)
            {
                jogos.Add(new JogoLocadoModel()
                {
                    Id = j.Id,
                    Nome = j.Nome,
                    Categoria = j.Categoria.ToString(),
                    NomeCliente = clienteRepositorio.BuscarPorId((int)j.IdCliente).Nome
                });
            }
            if (jogos.Count > 0)
            {
                var model = new RelatorioModel()
                {
                    JogosLocados = jogos,
                    QuantidadeDeJogos = jogos.Count()
                };
                return View(model);
            }
            return View(new RelatorioModel());
        }
        public ActionResult JogosDisponiveis(string nome)
        {
            var banco = new JogoRepositorio();

            var lista = string.IsNullOrWhiteSpace(nome) ? banco.BuscarTodos().ToList() : banco.BuscarPorNome(nome).ToList();
            lista = lista.Where(j => j.IdCliente == null).ToList();
            List<JogoModel> jogos = new List<JogoModel>();

            foreach (var j in lista)
            {
                jogos.Add(new JogoModel()
                {
                    Id = j.Id,
                    Nome = j.Nome,
                    Categoria = j.Categoria.ToString()
                });
            }
            if (jogos.Count > 0)
            {
                var model = new RelatorioModel()
                {
                    JogosDisponiveis = jogos,
                    QuantidadeDeJogos = jogos.Count()
                };
                return View(model);
            }
            return View(new RelatorioModel());
        }
        public JsonResult JogosAutocomplete(string term)
        {
            var banco = new JogoRepositorio();
            IList<Jogo> jogosEncontrados = string.IsNullOrEmpty(term) ? banco.BuscarTodos() : banco.BuscarPorNome(term);

            var json = jogosEncontrados.Select(x => new { label = x.Nome });

            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}