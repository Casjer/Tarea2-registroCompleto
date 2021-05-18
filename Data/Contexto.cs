using Microsoft.EntityFrameworkCore;
using RegistroCliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistroCliente.Data
{
    public class Contexto : DbContext
    {
        public DbSet<Clientes> Clientes { get; set; }
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public Contexto()
        {
        }
    }
}
