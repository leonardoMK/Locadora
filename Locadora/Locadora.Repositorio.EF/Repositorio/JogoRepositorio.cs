using Locadora.Dominio;
using Locadora.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Repositorio.EF
{
    public class JogoRepositorio : IJogoRepositorio
    {
        public int Atualizar(Jogo jogo)
        {
            using (BaseDeDados db = new BaseDeDados())
            {
                db.Entry(jogo).State = EntityState.Modified;
                return db.SaveChanges();
            }
        }

        public Jogo BuscarPorId(int id)
        {
            using (BaseDeDados bd = new BaseDeDados())
            {
                //bd.Jogo.Include("Cliente").Where(j => j.Id == id).FirstOrDefault();
                var jogo = bd.Jogo.Where(j => j.Id == id).FirstOrDefault();
                return jogo;

            }
        }

        public IList<Jogo> BuscarPorNome(string nome)
        {
            using (BaseDeDados bd = new BaseDeDados())
            {
                return bd.Jogo.Where(j => j.Nome.Contains(nome)).ToList();
            }
        }

        public IList<Jogo> BuscarTodos()
        {
            using (BaseDeDados bd = new BaseDeDados())
            {
                var jogo = bd.Jogo.ToList();
                return jogo;
            }
        }

        public int Criar(Jogo jogo)
        {
            using (BaseDeDados bd = new BaseDeDados())
            {
                bd.Entry(jogo).State = EntityState.Added;
                return bd.SaveChanges();
            }
        }

        public int Excluir(int id)
        {
            using (BaseDeDados bd = new BaseDeDados())
            {
                var jogo = bd.Jogo.Where(c => c.Id == id);
                bd.Entry(jogo).State = EntityState.Deleted;

                return bd.SaveChanges();
            }
        }
        public int BuscarQtdDeJogosPorClientes(Cliente cliente)
        {
            using (var db = new BaseDeDados())
            {
                return db.Jogo.Where(p => p.ClienteLocacao.Id == cliente.Id).ToList().Count();
            }
        }
    }
}
