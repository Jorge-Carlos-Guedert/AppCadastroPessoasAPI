using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppCadastroPessoasAPI.Models.Entities
{
   

    public class Horario
    {
        public int Id { get; set; }
        public string Hora { get; set; }
        public int Vagas { get; set; }

        // Tornar as FKs opcionais
        public int? DiaSemanaCalendarioId { get; set; }
        public int? DataEspecificaCalendarioId { get; set; }

        // Propriedades de navegação
        public virtual DiaSemanaCalendario DiaSemanaCalendario { get; set; }
        public virtual DataEspecificaCalendario DataEspecificaCalendario { get; set; }
    }
}