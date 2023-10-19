using APIList.Models;
using APIList.Repositories;
using APIList.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        private readonly ITarefasRepositorie _tarefaRepositorie;

        public TarefasController(ITarefasRepositorie tarefasRepositorie)
        {
            _tarefaRepositorie = tarefasRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTodasTarefas()
        {
            try
            {
                List<TarefaModel> tarefas = await _tarefaRepositorie.BuscarTodasTarefas();

                return Ok(tarefas);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Código 01 - Entre em contato com administrador  do sistema." });
            }
                       
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<TarefaModel>>> BuscarTarefaPorId(int id)
        {
            try
            {
                TarefaModel tarefa = await _tarefaRepositorie.BuscarTarefaPorId(id);

                return Ok(tarefa);
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Código 01 - Entre em contato com administrador  do sistema." });
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<TarefaModel>> AdicionarTarefas([FromBody] TarefaModel tarefaModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                TarefaModel tarefa = await _tarefaRepositorie.AdicionarTarefas(tarefaModel);

                return Ok(tarefa);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Código 01 - Entre em contato com administrador  do sistema." });
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> AtualizarTarefas([FromBody] TarefaModel tarefaModel, int id)
        {
            try
            {
                tarefaModel.Id = id;
                TarefaModel tarefa = await _tarefaRepositorie.AtualizarTarefas(tarefaModel, id);

                return Ok(tarefa);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Código 01 - Entre em contato com administrador  do sistema." });
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Deletar(int id)
        {
            try
            {
                bool deletado = await _tarefaRepositorie.Deletar(id);

                return Ok(deletado);
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Código 01 - Entre em contato com administrador  do sistema." });
            }
            
        }
    }
}
