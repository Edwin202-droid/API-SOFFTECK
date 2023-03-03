﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Data
{
    public class SoftteckContext : DbContext
    {
        public SoftteckContext(DbContextOptions<SoftteckContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "SOFTTECK-BD");
            optionsBuilder.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));

        }


        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Representante> Representantes { get; set; }
        public DbSet<Producto> Producto { get; set; }
    }
}
