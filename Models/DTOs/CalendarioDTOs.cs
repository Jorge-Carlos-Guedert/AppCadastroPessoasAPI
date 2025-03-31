namespace AppCadastroPessoasAPI.Models.DTOs
{
    public class CalendarioDTOs
    {
        

            public int Ano { get; set; }
            public int Mes { get; set; }
            public string PrimeiroDiaSemana { get; set; }
            public List<DiaSemanaDTO> DiasSemana { get; set; } = new List<DiaSemanaDTO>();
            public List<DataEspecificaDTO> DatasEspecificas { get; set; } = new List<DataEspecificaDTO>();
        }

      

       
    }

