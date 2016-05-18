using Locadora.Repositorio.EF;
using Locadora.Web.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locadora.Web.MVC.Seguranca;
using Locadora.Dominio;

namespace Locadora.Web.MVC.Controllers
{
    //TODO: Remover duplicação de código;
    [Autorizador]
    public class JogoController : Controller
    {
        [HttpGet]
        public ActionResult Detalhes(int id)
        {
            var banco = new JogoRepositorio();
            var j = banco.BuscarPorId(id);
            JogoDetalhesModel jogo = new JogoDetalhesModel()
            {
                Id = j.Id,
                Nome = j.Nome,
                Categoria = j.Categoria,
                Descricao = j.Descricao,
                Selo = j.Selo,
                Imagem = String.IsNullOrEmpty(j.Imagem) ? "http://imobiliariaprimos.com.br/imagens/imoveis/sem_imagem.jpg" : j.Imagem,
                Video = j.Video
            };

            var model = jogo;
            return View(jogo);
        }
        [Autorizador(Roles = Permissao.ADMIN)]
        [HttpGet]
        public ActionResult ManterJogo(int? id)
        {
            var banco = new JogoRepositorio();
            if (id.HasValue)
            {
                var jogo = banco.BuscarPorId((int)id);
                var model = new JogoDetalhesModel()
                {
                    Id = jogo.Id,
                    Nome = jogo.Nome,
                    Categoria = jogo.Categoria,
                    Descricao = jogo.Descricao,
                    Selo = jogo.Selo,
                    Imagem = jogo.Imagem,
                    Video = jogo.Video

                };
                return View(model);
            }
            else
            {
                return View();
            }
        }
        [Autorizador(Roles = Permissao.ADMIN)]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Salvar(JogoDetalhesModel model)
        {
            var database = new JogoRepositorio();
            if (ModelState.IsValid)
            {
                var jogo = database.BuscarPorNome(model.Nome).ToList();
                if (jogo.Count > 0)
                {
                    try
                    {
                        database.Atualizar(new Dominio.Jogo(jogo[0].Id)
                        {
                            Nome = model.Nome,
                            Categoria = model.Categoria,
                            Imagem = model.Imagem,
                            Video = model.Video,
                            Selo = model.Selo,
                            Descricao = model.Descricao
                        });
                        TempData["Mensagem"] = "Jogo Atualizado com Sucesso!!";

                    }
                    catch (SqlException)
                    {
                        TempData["Mensagem"] = "Problema na atualização dos dados no banco,"
                            + " por favor digite os dados corretamente";
                    }
                    return View("ManterJogo", model);

                }
                else
                {
                    try
                    {
                        database.Criar(new Dominio.Jogo()
                        {
                            Nome = model.Nome,
                            Categoria = model.Categoria,
                            Imagem = model.Imagem,
                            Video = model.Video,
                            Selo = model.Selo,
                            Descricao = model.Descricao
                        });
                        TempData["Mensagem"] = "Jogo Salvo com Sucesso!!";
                        model.Id = database.BuscarPorNome(model.Nome)[0].Id;
                    }
                    catch (Exception)
                    {
                        TempData["Mensagem"] = "Problema na inserção dos dados no banco,"
                            + " por favor digite os dados corretamente";
                    }
                    return View("ManterJogo", model);
                }
            }
            else
            {
                return View("ManterJogo", model);
            }
        }
    }
}