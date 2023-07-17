using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.DTOs;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaDto>>> Get(
            [FromServices] ITarefaRepositorio repositorio)
        {
            var resultado = await repositorio.ObterComCardEResponsavelAsync();

            if (resultado == null)
                return BadRequest("Não foi possível retornar as informações");

            return Ok(resultado);
        }

        // GET api/<TarefaController>/5
        [HttpGet("{id}")]
        public async Task<TarefaDto> Get(
            int id,
            [FromServices] ITarefaRepositorio repositorio,
            [FromServices] IMapper mapper)
        {
            var tarefa = await repositorio.ObterComCardEResponsavelPorIdAsync(id);

            var tarefaDto = mapper.Map<TarefaDto>(tarefa);

            return tarefaDto;
        }

        // POST api/<TarefaController>
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] TarefaDto dto,
            [FromServices] IArmazenadorDeTarefa armazenador)
        {
            if (dto == null)
                return BadRequest("A dto não pode ser nula.");

            var tarefa = await armazenador.Armazenar(dto);

            if (tarefa == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao armazenar a Tarefa.");

            return Ok(tarefa);
        }

        // DELETE api/<TarefaController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(
            int id,
            [FromServices] IExcluidorDeTarefa excluidor)
        {
            try
            {
                await excluidor.Excluir(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao tentar excluir o item.");
            }

            return Ok(true);
        }
    }
}
