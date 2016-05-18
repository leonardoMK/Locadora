using Locadora.Dominio;
using Locadora.Dominio.Servicos;
using Locadora.Repositorio.EF;
using Locadora.Web.MVC.Models;
using Locadora.Web.MVC.Seguranca;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Locadora.Web.MVC.Controllers
{
    [Autorizador]
    public class LocacaoController : Controller
    {
        public ActionResult Locar(int id)
        {
            var jogoRepositorio = new JogoRepositorio();
            Jogo jogo = jogoRepositorio.BuscarPorId(id);
            var servicoLocacao = new ServicoLocacao() { JogoRepositorio= jogoRepositorio };
            var dataPrevista = servicoLocacao.GerarDataDevolucao(jogo);
            var telaLocacao = new TelaLocacaoModel()
            {
                Id = jogo.Id,
                NomeJogo = jogo.Nome,
                Selo = jogo.Selo,
                Imagem = string.IsNullOrEmpty(jogo.Imagem) ? "http://imobiliariaprimos.com.br/imagens/imoveis/sem_imagem.jpg" : jogo.Imagem,
                DataPrevista = string.Format("{0:dd/MM/yyyy}", dataPrevista),
                ValorDaLocacao = jogo.GerarValorDaLocacao().ToString("C")
            };
            return View(telaLocacao);
        }
        public JsonResult ClienteAutocomplete(string term)
        {
            var banco = new ClienteRepositorio();
            IList<Cliente> jogosEncontrados = string.IsNullOrWhiteSpace(term) ? banco.BuscarTodos() : banco.BuscarPorNome(term);

            var json = jogosEncontrados.Select(x => new { label = x.Nome });

            return Json(json, JsonRequestBehavior.AllowGet);
        }


        public ActionResult Salvar(string clienteNome, int id)
        {
            if (String.IsNullOrWhiteSpace(clienteNome))
            {
                TempData["Mensagem"] = "Erro na busca do cliente";
                return RedirectToAction("JogosDisponiveis","Relatorio");
            }
            var repositorio = new ClienteRepositorio();
            var jogoRepositorio = new JogoRepositorio();
            var servicoLocacao = new ServicoLocacao() { JogoRepositorio=jogoRepositorio};
            var jogo = jogoRepositorio.BuscarPorId(id);
            var cliente = repositorio.BuscarPorNome(clienteNome).FirstOrDefault();
            if (servicoLocacao.PodeLocar(cliente))
            {
                var data = servicoLocacao.GerarDataDevolucao(jogo);
                if (cliente != null)
                {
                    jogo.IdCliente = cliente.Id;
                    jogo.LocarPara(cliente);
                    jogo.DataDevolucao = data;
                    jogoRepositorio.Atualizar(jogo);
                    TempData["Mensagem"] = "Jogo Locado com Sucesso";
                }
            }
            else
            {
                TempData["Mensagem"] = "Cliente não pode locar mais jogos";
            }
            return RedirectToAction("JogosDisponiveis", "Relatorio");
        }
        public ActionResult DevolverJogo(int id)
        {
            var jogoRepositorio = new JogoRepositorio();
            var clienteRepositorio = new ClienteRepositorio();
            var servicoLocacao = new ServicoLocacao() { JogoRepositorio = jogoRepositorio };
            Jogo jogo = jogoRepositorio.BuscarPorId(id);
            TempData["Cliente"] = clienteRepositorio.BuscarPorId((int)jogo.IdCliente).Nome;
            TempData["Valor"] = jogo.GerarValorDaLocacao().ToString("C");
            bool devolver =servicoLocacao.DevolverJogo(jogo);
            if (devolver)
            {
                TempData["Mensagem"] = "Jogo Devolvido!";
                TempData["DataEntrega"] = String.Format("{0:dd/MM/yyyy}",DateTime.Now.Date);
                return RedirectToAction("JogosLocados", "Relatorio");
            }
            TempData["Mensagem"] = "Falha na devolução";
            return RedirectToAction("JogosLocados", "Relatorio");
        }

    }
}