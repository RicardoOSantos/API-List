using APIList.Data;
using APIList.Models;
using APIList.Repositories.Interface;
using Microsoft.EntityFrameworkCore;

namespace APIList.Repositories
{
    public class TarefasRepositorie : ITarefasRepositorie
    {
        private readonly TarefasDBContext _dbContext;

        public TarefasRepositorie(TarefasDBContext tarefasdbContext)
        {
            _dbContext = tarefasdbContext;
        }
        public async Task<TarefaModel> AdicionarTarefas(TarefaModel tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();

            return tarefa;
        }

        public async Task<TarefaModel> AtualizarTarefas(TarefaModel tarefa, int id)
        {
            TarefaModel tarefaPorId = await BuscarTarefaPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada no banco de dados.");
            }
            tarefaPorId.Tarefa = tarefa.Tarefa;
            tarefaPorId.Descricao = tarefa.Descricao;
            tarefaPorId.Status = tarefa.Status;
            

            _dbContext.Tarefas.Update(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return tarefaPorId;
        }

        public async Task<TarefaModel> BuscarTarefaPorId(int id)
        {
            return await _dbContext.Tarefas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TarefaModel>> BuscarTodasTarefas()
        {
            return await _dbContext.Tarefas.ToListAsync();
        }

        public async Task<bool> Deletar(int id)
        {
            TarefaModel tarefaPorId = await BuscarTarefaPorId(id);

            if (tarefaPorId == null)
            {
                throw new Exception($"Tarefa para o ID: {id} não foi encontrada no banco de dados.");
            }

            _dbContext.Tarefas.Remove(tarefaPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
