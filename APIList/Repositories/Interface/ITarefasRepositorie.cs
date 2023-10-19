using APIList.Models;

namespace APIList.Repositories.Interface
{
    public interface ITarefasRepositorie
    {
        Task<List<TarefaModel>> BuscarTodasTarefas();
        Task<TarefaModel> BuscarTarefaPorId(int id);
        Task<TarefaModel> AdicionarTarefas(TarefaModel tarefa);
        Task<TarefaModel> AtualizarTarefas(TarefaModel tarefa, int id);
        Task<bool> Deletar(int id);
    }
}
