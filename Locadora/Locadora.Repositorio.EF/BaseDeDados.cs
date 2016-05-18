using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locadora.Dominio;
using System.Data.Entity.ModelConfiguration;
using Locadora.Repositorio.EF.Mapping;

namespace Locadora.Repositorio.EF
{
    public class BaseDeDados : DbContext
    {
        public BaseDeDados() : base("LOCADORACF")
        {

        }
        public DbSet<Jogo> Jogo { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Permissao> Permissao { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<BaseDeDados>(null);
            modelBuilder.Configurations.Add(new ClienteMap());
            modelBuilder.Configurations.Add(new JogoMap());
            modelBuilder.Configurations.Add(new UsuarioMap());
            modelBuilder.Configurations.Add(new PermissaoMap());
            base.OnModelCreating(modelBuilder);
        }
    }
}
