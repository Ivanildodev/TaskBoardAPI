using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.DTOs;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDto>>> Get(
            [FromServices] ICardRepositorio repositorio)
        {
            var resultado = await repositorio.ObterAsync();

            if(resultado == null)
                return BadRequest("Não foi possível retornar as informações");

            return Ok(resultado);
        }

        // GET api/<CardController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(
            int id,
            [FromServices] ICardRepositorio repositorio,
            [FromServices] IMapper mapper)
        {
            var card = await repositorio.ObterPorIdAsync(id);

            var dto = mapper.Map<CardDto>(card);

            return Ok(dto);
        }

        // POST api/<CardController>
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] CardDto dto,
            [FromServices] IArmazenadorDeCard armazenador)
        {
            if (dto == null)
                return BadRequest("A dto não pode ser nula.");

            var card = await armazenador.Armazenar(dto);

            if (card == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao armazenar o Card.");
            }

            return Ok(card);
        }

        // DELETE api/<CardController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(
            int id,
            [FromServices] IExcluidorDeCard excluidor)
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
