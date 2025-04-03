namespace AppCadastroPessoasAPI.Models.DTOs
{
    public class DataEspecificaDTO
    {
        public DateTime Data { get; set; } // Alterado de 'int Dia' para 'DateTime Data'
        public List<HorarioDTO> Horarios { get; set; } = new List<HorarioDTO>();
    }
}
