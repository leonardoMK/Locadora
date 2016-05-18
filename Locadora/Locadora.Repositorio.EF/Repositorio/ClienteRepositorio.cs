using Locadora.Dominio.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Dominio;

namespace Locadora.Repositorio.EF
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        public IList<Cliente> BuscarPorNome(string nome)
        {
            using (BaseDeDados db = new BaseDeDados())
            {
                return db.Cliente.Where(j => j.Nome.Contains(nome)).ToList();
            }
        }
        public IList<Cliente> BuscarTodos()
        {
            using (var db = new BaseDeDados())
            {
                return db.Cliente.ToList();
            }
        }
        public Cliente BuscarPorId(int id)
        {
            using(var db = new BaseDeDados())
            {
                return db.Cliente.FirstOrDefault(c => c.Id == id);
            }
        }
    }
}
