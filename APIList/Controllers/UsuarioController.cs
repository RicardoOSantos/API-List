using APIList.Models;
using APIList.Repositories.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace APIList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorie _usuarioRepositorie;

        public UsuarioController(IUsuarioRepositorie usuarioRepositorie)
        {
            _usuarioRepositorie = usuarioRepositorie;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            try
            {
                List<UsuarioModel> usuarios = await _usuarioRepositorie.BuscarTodosUsuarios();

                return Ok(usuarios);
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Código 01 - Entre em contato com administrador  do sistema." });
            }
             
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarPorId(int id)
        {
            try
            {
                UsuarioModel usuario = await _usuarioRepositorie.BuscarPorId(id);

                return Ok(usuario);
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Código 01 - Entre em contato com administrador  do sistema." });
            }
            
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Adicionar([FromBody] UsuarioModel usuarioModel)
        {
            try
            {
                UsuarioModel usuario = await _usuarioRepositorie.Adicionar(usuarioModel);

                return Ok(usuario);
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Código 01 - Entre em contato com administrador  do sistema." });
            }
            
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            try
            {
                usuarioModel.Id = id;
                UsuarioModel usuario = await _usuarioRepositorie.Atualizar(usuarioModel, id);

                return Ok(usuario);
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Código 01 - Entre em contato com administrador  do sistema." });
            }
            
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Deletar(int id)
        {
            try
            {
                bool deletado = await _usuarioRepositorie.Deletar(id);

                return Ok(deletado);
            }
            catch (Exception)
            {

                return BadRequest(new { message = "Código 01 - Entre em contato com administrador  do sistema." });
            }
            
        }
    }
}
