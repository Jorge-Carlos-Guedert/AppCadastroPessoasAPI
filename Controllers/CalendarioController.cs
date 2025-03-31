using AppCadastroPessoasAPI.Data;

using AppCadastroPessoasAPI.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace AppCadastroPessoasAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalendarioController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CalendarioController(AppDbContext context)
        {
            _context = context;
        }
        public class CalendarioDTO
        {
            public int Ano { get; set; }
            public int Mes { get; set; }
            public string PrimeiroDiaSemana { get; set; }
            public List<DiaSemanaDTO> DiasSemana { get; set; } = new List<DiaSemanaDTO>();
            public List<DataEspecificaDTO> DatasEspecificas { get; set; } = new List<DataEspecificaDTO>();
        }

        public class DiaSemanaDTO
        {
            public string Nome { get; set; }
            public List<HorarioDTO> Horarios { get; set; } = new List<HorarioDTO>();
        }

        public class DataEspecificaDTO
        {
            public int Dia { get; set; }
            public List<HorarioDTO> Horarios { get; set; } = new List<HorarioDTO>();
        }

        public class HorarioDTO
        {
            public string Hora { get; set; }
            public int Vagas { get; set; }
        }
        [HttpPost]
        public async Task<IActionResult> SalvarCalendario([FromBody] CalendarioDTO calendarioDTO)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Verifica e remove calendário existente
                await LimparCalendarioExistente(calendarioDTO.Ano, calendarioDTO.Mes);

                // Cria novo calendário
                var novoCalendario = new Calendario
                {
                    Ano = calendarioDTO.Ano,
                    Mes = calendarioDTO.Mes,
                    PrimeiroDiaSemana = calendarioDTO.PrimeiroDiaSemana
                };

                // Adiciona dias da semana
                foreach (var diaDTO in calendarioDTO.DiasSemana)
                {
                    var dia = new DiaSemanaCalendario
                    {
                        Nome = diaDTO.Nome,
                        Calendario = novoCalendario
                    };

                    foreach (var horarioDTO in diaDTO.Horarios)
                    {
                        dia.Horarios.Add(new Horario
                        {
                            Hora = horarioDTO.Hora,
                            Vagas = horarioDTO.Vagas
                        });
                    }

                    novoCalendario.DiasSemana.Add(dia);
                }

                // Adiciona datas específicas
                foreach (var dataDTO in calendarioDTO.DatasEspecificas)
                {
                    var data = new DataEspecificaCalendario
                    {
                        Dia = dataDTO.Dia,
                        Calendario = novoCalendario
                    };

                    foreach (var horarioDTO in dataDTO.Horarios)
                    {
                        data.Horarios.Add(new Horario
                        {
                            Hora = horarioDTO.Hora,
                            Vagas = horarioDTO.Vagas
                        });
                    }

                    novoCalendario.DatasEspecificas.Add(data);
                }

                _context.Calendario.Add(novoCalendario);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return Ok(new { message = "Calendário salvo com sucesso!" });
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpDelete("{ano}/{mes}")]
        public async Task<IActionResult> LimparCalendarioExistente(int ano, int mes)
        {
            try
            {
                var calendarioExistente = await _context.Calendario
                    .Include(c => c.DiasSemana)
                        .ThenInclude(d => d.Horarios)
                    .Include(c => c.DatasEspecificas)
                        .ThenInclude(d => d.Horarios)
                    .FirstOrDefaultAsync(c => c.Ano == ano && c.Mes == mes);

                if (calendarioExistente != null)
                {
                    // Remove todos os horários associados
                    foreach (var dia in calendarioExistente.DiasSemana)
                    {
                        _context.Horarios.RemoveRange(dia.Horarios);
                    }

                    foreach (var data in calendarioExistente.DatasEspecificas)
                    {
                        _context.Horarios.RemoveRange(data.Horarios);
                    }

                    // Remove os dias e datas
                    _context.DiasSemana.RemoveRange(calendarioExistente.DiasSemana);
                    _context.DatasEspecificas.RemoveRange(calendarioExistente.DatasEspecificas);

                    // Remove o calendário
                    _context.Calendario.Remove(calendarioExistente);

                    await _context.SaveChangesAsync();
                }

                return Ok(new { message = "Dados do calendário limpos com sucesso." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpGet("{ano}/{mes}")]
        public async Task<IActionResult> ObterCalendario(int ano, int mes)
        {
            try
            {
                var calendario = await _context.Calendario
                    .Include(c => c.DiasSemana)
                        .ThenInclude(d => d.Horarios)
                    .Include(c => c.DatasEspecificas)
                        .ThenInclude(d => d.Horarios)
                    .FirstOrDefaultAsync(c => c.Ano == ano && c.Mes == mes);

                if (calendario == null)
                {
                    return NotFound();
                }

                var calendarioDTO = new CalendarioDTO
                {
                    Ano = calendario.Ano,
                    Mes = calendario.Mes,
                    PrimeiroDiaSemana = calendario.PrimeiroDiaSemana,
                    DiasSemana = calendario.DiasSemana.Select(d => new DiaSemanaDTO
                    {
                        Nome = d.Nome,
                        Horarios = d.Horarios.Select(h => new HorarioDTO
                        {
                            Hora = h.Hora,
                            Vagas = h.Vagas
                        }).ToList()
                    }).ToList(),
                    DatasEspecificas = calendario.DatasEspecificas.Select(d => new DataEspecificaDTO
                    {
                        Dia = d.Dia,
                        Horarios = d.Horarios.Select(h => new HorarioDTO
                        {
                            Hora = h.Hora,
                            Vagas = h.Vagas
                        }).ToList()
                    }).ToList()
                };

                return Ok(calendarioDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }
    }
}