using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.DTOs;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CargoDto>>> Get(
            [FromServices] ICargoRepositorio repositorio)
        {
            var resultado = await repositorio.ObterAsync();

            if (resultado == null)
                return BadRequest("Não foi possível retornar as informações");

            return Ok(resultado);
        }

        // GET api/<CargoController>/5
        [HttpGet("{id}")]
        public async Task<CargoDto> Get(
            int id,
            [FromServices] ICargoRepositorio repositorio,
            [FromServices] IMapper mapper)
        {
            var cargo = await repositorio.ObterPorIdAsync(id);

            var cargoDto = mapper.Map<CargoDto>(cargo);

            return cargoDto;
        }

        // POST api/<CargoController>
        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] CargoDto dto,
            [FromServices] IArmazenadorDeCargo armazenador)
        {
            if (dto == null)
                return BadRequest("A dto não pode ser nula.");

            var cargo = await armazenador.Armazenar(dto);

            if (cargo == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Ocorreu um erro ao armazenar o Cargo.");

            return Ok(cargo);
        }

        // DELETE api/<CargoController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(
            int id,
            [FromServices] IExcluidorDeCargo excluidor)
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
