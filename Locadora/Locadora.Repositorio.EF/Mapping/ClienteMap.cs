﻿using Locadora.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Repositorio.EF.Mapping
{
    class ClienteMap : EntityTypeConfiguration<Cliente>
    {
        public ClienteMap()
        {
            ToTable("cliente");
            HasKey(c => c.Id);
            Property(c => c.Nome).IsRequired().HasColumnName("Nome").HasMaxLength(250);
        }
    }
}
