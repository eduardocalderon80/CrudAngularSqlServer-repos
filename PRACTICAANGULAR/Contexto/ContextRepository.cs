using Microsoft.EntityFrameworkCore;
using PRACTICAANGULAR.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PRACTICAANGULAR.Contexto
{
    public class ContextRepository : DbContext
    {
        public ContextRepository(DbContextOptions<ContextRepository> options) : base(options)
        {

        }

        public DbSet<Value> Value { get; set; }
    }
}
