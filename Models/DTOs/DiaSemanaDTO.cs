namespace AppCadastroPessoasAPI.Models.DTOs
{
    public class DiaSemanaDTO
    {
        public string Nome { get; set; }
        public List<HorarioDTO> Horarios { get; set; } = new List<HorarioDTO>();
    }
}
