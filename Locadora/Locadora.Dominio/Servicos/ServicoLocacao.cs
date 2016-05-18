using Locadora.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Dominio.Servicos
{
    public class ServicoLocacao
    {
        public IJogoRepositorio JogoRepositorio { get; set; }
        public IClienteRepositorio ClienteRepositorio { get; set; }
        public DateTime GerarDataDevolucao(Jogo jogo)
        {
            if (jogo.Selo == Selo.Bronze)
            {
                jogo.DataDevolucao = DateTime.Now.AddDays(3);
            }
            else if (jogo.Selo == Selo.Prata)
            {
                jogo.DataDevolucao = DateTime.Now.AddDays(2);
            }
            else
            {
                jogo.DataDevolucao = DateTime.Now.AddDays(1);
            }
            return (DateTime)jogo.DataDevolucao;
        }   
        public bool DevolverJogo(Jogo jogo)
        {
            jogo.Devolver();
            int atualizar =JogoRepositorio.Atualizar(jogo);
            if(atualizar != 1)
            {
                return false;
            }
            return true;
        }

        public bool PodeLocar(Cliente cliente)
        {
            //TODO: Levar count para repositorio do jogo
            int quantidade = JogoRepositorio.BuscarQtdDeJogosPorClientes(cliente);
            
                if (quantidade < 3)
                {
                    return true;
                }
                return false;
        }
    }
}
