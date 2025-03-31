using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppCadastroPessoasAPI.Models.Entities
{
    public class DataEspecificaCalendario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Dia { get; set; }

        [ForeignKey("Calendario")]
        public int CalendarioId { get; set; }
        public virtual Calendario Calendario { get; set; }

        public virtual ICollection<Horario> Horarios { get; set; } = new List<Horario>();
    }
}
