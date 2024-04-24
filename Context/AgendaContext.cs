using Microsoft.EntityFrameworkCore;
using SistemaTarefas.Models;

namespace SistemaTarefas.Context 
{
    public class AgendaContext : DbContext
    {
        public AgendaContext(DbContextOptions<AgendaContext> options) : base(options)
        {

        }

        public DbSet<Tarefa> Tarefas { get; set; }
    }
}