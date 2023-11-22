using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Trabalho_Back_End.Entities;


namespace Trabalho_Back_End.Context
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base (options)
        {

        }

        public DbSet<Contato> Contatos { get; set; }
        
    }
}