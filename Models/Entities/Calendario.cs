using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AppCadastroPessoasAPI.Models.Entities
{
    public class Calendario
    {
        public int Id { get; set; }
        public int Ano { get; set; }
        public int Mes { get; set; }
        public string PrimeiroDiaSemana { get; set; }

        // Coleções
        public virtual ICollection<DiaSemanaCalendario> DiasSemana { get; set; } = new List<DiaSemanaCalendario>();
        public virtual ICollection<DataEspecificaCalendario> DatasEspecificas { get; set; } = new List<DataEspecificaCalendario>();
    }






}
