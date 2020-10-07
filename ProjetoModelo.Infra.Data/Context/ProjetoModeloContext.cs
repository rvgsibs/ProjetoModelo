using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using MySql.Data.EntityFramework;
using ProjetoModelo.Domain.Entities;

namespace ProjetoModelo.Infra.Data.Context
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class ProjetoModeloContext : DbContext
    {      
        public ProjetoModeloContext()
            : base("DefaultConnection")
        {

        }

        public DbSet<Product> Product { get; set; }
    }

}
