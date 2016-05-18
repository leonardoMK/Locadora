using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Dominio.Test
{
    [TestClass]
    public class JogoTest
    {
        [TestMethod]
        public void JogoADeveSerIgualJogoB()
        {
            Jogo jogoA = new Jogo(id: 1, cliente: null);
            Jogo jogoB = new Jogo(id: 1, cliente: null);
            
            Assert.AreEqual(jogoA, jogoB);
        }

        [TestMethod]
        public void LocacaoParaClienteTemIdCorreto()
        {
            Jogo jogo = new Jogo();

            jogo.LocarPara(new Cliente(id: 1));

            Assert.AreEqual(1, jogo.ClienteLocacao.Id);
        }
        [TestMethod]
        public void ValorDeJogoComSeloBronzeEh5()
        {
            Jogo jogo = new Jogo();
            jogo.Selo = Selo.Bronze;
            jogo.DataDevolucao = DateTime.Now;
            var valorEsperado = 5;
            Assert.AreEqual(valorEsperado, jogo.GerarValorDaLocacao());
        }
        [TestMethod]
        public void ValorDeJogoComSeloPrataEh10()
        {
            Jogo jogo = new Jogo();
            jogo.Selo = Selo.Prata;
            jogo.DataDevolucao = DateTime.Now;
            var valorEsperado = 10;
            Assert.AreEqual(valorEsperado, jogo.GerarValorDaLocacao());
        }
        [TestMethod]
        public void ValorBronzeComAtrasoDeUmDia()
        {
            Jogo jogo = new Jogo();
            jogo.Selo = Selo.Bronze;
            jogo.DataDevolucao = DateTime.Now.AddDays(-1);
            var valorEsperado = 10;
            Assert.AreEqual(valorEsperado, jogo.GerarValorDaLocacao());
        }
        [TestMethod]
        public void ValorDoSeloOuroComDataAtrasadaEmTresDias()
        {
            Jogo jogo = new Jogo();
            jogo.Selo = Selo.Ouro;
            jogo.DataDevolucao = DateTime.Now.AddDays(-3);
            var valorEsperado = 30;
            Assert.AreEqual(valorEsperado, jogo.GerarValorDaLocacao());
        }
    }
}
