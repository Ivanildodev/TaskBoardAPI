using TaskBoardAPI.Data.Repositories.Interfaces;
using TaskBoardAPI.Services.Interfaces;

namespace TaskBoardAPI.Services
{
    public class ExcluidorDeTarefa : IExcluidorDeTarefa
    {
        private readonly ITarefaRepositorio _tarefaRepositorio;

        public ExcluidorDeTarefa(ITarefaRepositorio tarefaRepositorio)
        {
            _tarefaRepositorio = tarefaRepositorio;
        }

        public async Task Excluir(int id)
        {
            var tarefa = await _tarefaRepositorio.ObterPorIdAsync(id);

            if(tarefa != null)
                await _tarefaRepositorio.DeleteAsync(id);
        }
    }
}
