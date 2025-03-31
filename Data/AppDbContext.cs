using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using AppCadastroPessoasAPI.Models;
using System.Globalization;
using AppCadastroPessoasAPI.Models.Entities;

namespace AppCadastroPessoasAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Calendario> Calendario { get; set; } // Singular
        public DbSet<DiaSemanaCalendario> DiasSemana { get; set; }
        public DbSet<DataEspecificaCalendario> DatasEspecificas { get; set; }
        public DbSet<Horario> Horarios { get; set; }


    }


    


}