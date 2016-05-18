using Locadora.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Repositorio.EF.Mapping
{
    class JogoMap : EntityTypeConfiguration<Jogo>
    {
        public JogoMap()
        {
            ToTable("jogo");
            HasKey(j => j.Id);
            Property(j => j.Nome).IsRequired().HasColumnName("Nome").HasMaxLength(250);
            Property(j => j.Descricao).IsRequired().HasColumnName("Descricao").HasMaxLength(1500);
            Property(j => j.Imagem).IsOptional().HasColumnName("Imagem").HasMaxLength(200);
            Property(j => j.Video).IsOptional().HasColumnName("Video").HasMaxLength(200);
            Property(p => p.IdCliente);

            HasOptional(p => p.ClienteLocacao).WithMany().HasForeignKey(p => p.IdCliente);
        }
    }
}
