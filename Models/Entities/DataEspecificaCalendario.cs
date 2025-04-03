using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AppCadastroPessoasAPI.Models.Entities
{
    public class DataEspecificaCalendario
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public int CalendarioId { get; set; }
        public virtual Calendario Calendario { get; set; }
        public virtual ICollection<Horario> Horarios { get; set; }
    }
}
