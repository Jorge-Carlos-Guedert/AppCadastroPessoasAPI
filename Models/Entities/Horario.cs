using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppCadastroPessoasAPI.Models.Entities
{
    public class Horario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Hora { get; set; } // Formato HH:mm

        [Required]
        public int Vagas { get; set; }

        [ForeignKey("DiaSemanaCalendario")]
        public int? DiaSemanaCalendarioId { get; set; }
        public virtual DiaSemanaCalendario DiaSemanaCalendario { get; set; }

        [ForeignKey("DataEspecificaCalendario")]
        public int? DataEspecificaCalendarioId { get; set; }
        public virtual DataEspecificaCalendario DataEspecificaCalendario { get; set; }
    }
}
