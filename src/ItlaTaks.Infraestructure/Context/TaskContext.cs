using ItlaTaks.Domain.Entities.Relations;
using ItlaTaks.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItlaTaks.Infraestructure.Context
{
    public class TaskContext : DbContext
    {
        public TaskContext()
        {
                
        }
        public TaskContext(DbContextOptions<TaskContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Persist Security Info=False;Trusted_Connection=True;database=TaskItla;server=(local);TrustServerCertificate=True;");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<ProfesorMateriaModel>()
                .HasKey(pm => new { pm.IdProfesor, pm.MateriaId });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ProfesorMateriaModel> ProfesorMaterias { get; set; }
        public DbSet<ProfesorModel> Profesores { get; set; }
        public DbSet<MateriaModel> Materias { get; set; }

        }
}
