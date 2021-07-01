using System;
using todo.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace todo.Contexts
{
    public partial class TodoContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public TodoContext()
        { }
        public TodoContext(DbContextOptions<TodoContext> options): base(options)
        { }

       /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql("Host=localhost;Database=mydb;Username=postgres;Password=postgres");
 */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.ToTable("todos", "demo");
                entity.Property(e => e.Id)
                                    .HasColumnName("id")
                                    .HasDefaultValueSql("nextval('demo.todos_id_seq'::regclass)");
                entity.Property(e => e.Descripcion).HasColumnName("descripcion");
                entity.Property(e => e.Nombre)
                                    .IsRequired()
                                    .HasColumnName("nombre");
            });
            modelBuilder.HasSequence("todos_id_seq", "demo");
        }
    }
}
