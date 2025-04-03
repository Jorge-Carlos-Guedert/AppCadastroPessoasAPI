using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AppCadastroPessoasAPI.Models;
using System.Globalization;
using AppCadastroPessoasAPI.Models.Entities;
using Microsoft.Extensions.Options;

namespace AppCadastroPessoasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Calendario> Calendario { get; set; } // Deve vir primeiro
        public DbSet<DiaSemanaCalendario> DiasSemana { get; set; }
        public DbSet<DataEspecificaCalendario> DatasEspecificas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração para Calendario
            modelBuilder.Entity<Calendario>(entity =>
            {
                entity.HasMany(c => c.DiasSemana)
                      .WithOne(d => d.Calendario)
                      .HasForeignKey(d => d.CalendarioId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(c => c.DatasEspecificas)
                      .WithOne(d => d.Calendario)
                      .HasForeignKey(d => d.CalendarioId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            // Configuração para Horario (como você já tinha)
            modelBuilder.Entity<Horario>(entity =>
            {
            });

            // Configurações adicionais para as outras entidades se necessário
        }
    }





}