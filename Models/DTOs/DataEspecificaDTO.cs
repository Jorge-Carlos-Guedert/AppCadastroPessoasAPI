namespace AppCadastroPessoasAPI.Models.DTOs
{
    public class DataEspecificaDTO
    {
        public int Dia { get; set; }
        public List<HorarioDTO> Horarios { get; set; } = new List<HorarioDTO>();
    }
}
