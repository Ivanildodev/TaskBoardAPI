using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.DTOs;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColaboradorDto>>> Get(
            [FromServices] IColaboradorRepositorio repositorio)
        {
            var resultado = await repositorio.ObterComCargoAsync();

            if (resultado == null)
                return BadRequest("Não foi possível retornar as informações");

            return Ok(resultado);
        }

        // GET api/<ColaboradorController>/5
        [HttpGet("{id}")]
        public async Task<ColaboradorDto> Get(
            int id,
            [FromServices] IColaboradorRepositorio repositorio,
            [FromServices] IMapper mapper)
        {
            var colaborador = await repositorio.ObterPorIdAsync(id);

            var colaboradorDto = mapper.Map<ColaboradorDto>(colaborador);

            return colaboradorDto;
        }

        // POST api/<ColaboradorController>
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] ColaboradorDto dto,
            [FromServices] IArmazenadorDeColaborador armazenador)
        {
            if (dto == null)
                return BadRequest("A dto não pode ser nula.");

            var colaborador = await armazenador.Armazenar(dto);

            if (colaborador == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao armazenar o Colaborador.");

            return Ok(colaborador);
        }

        // DELETE api/<ColaboradorController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(
            int id,
            [FromServices] IExcluidorDeColaborador excluidor)
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
