using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Locadora.Dominio.Test
{
    [TestClass]
    public class LocacaoTest
    {
       [TestMethod]
       public void TestarDataPrevistaDoSeloDeOuro()
        {
            var servico = new Servicos.ServicoLocacao();
            var date =servico.GerarDataDevolucao(new Jogo() {Selo=Selo.Ouro }).Date;
            var dataEsperada = DateTime.Now.AddDays(1).Date;
            Assert.AreEqual(dataEsperada, date);
        }
        [TestMethod]
        public void TestarDataPrevistaDeFormaErradaRetornaErro()
        {
            var servico = new Servicos.ServicoLocacao();
            var date = servico.GerarDataDevolucao(new Jogo() { Selo = Selo.Ouro }).Date;
            var dataEsperada = DateTime.Now.AddDays(2).Date;
            Assert.AreNotEqual(dataEsperada, date);
        }
    }
}
