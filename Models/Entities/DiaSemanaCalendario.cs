using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppCadastroPessoasAPI.Models.Entities
{

    public class DiaSemanaCalendario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int CalendarioId { get; set; }
        public virtual Calendario Calendario { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
    }

}
