using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCadastroPessoasAPI.Models.Entities
{
    public class Calendario
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Ano { get; set; }

        [Required]
        public int Mes { get; set; }

        [Required]
        public string PrimeiroDiaSemana { get; set; }

        public virtual ICollection<DiaSemanaCalendario> DiasSemana { get; set; } = new List<DiaSemanaCalendario>();
        public virtual ICollection<DataEspecificaCalendario> DatasEspecificas { get; set; } = new List<DataEspecificaCalendario>();
    }

    

   

   
}
