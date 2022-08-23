using GerenciadorDeTarefas.Dtos;
using GerenciadorDeTarefas.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : BaseController
    {
        private readonly ILogger<UsuarioController> _logger;
        public UsuarioController(ILogger<UsuarioController> logger)
        {
            _logger = logger; 
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SalvarUsuario([FromBody] Usuario usuario)
        {
            try
            {
                var erros = new List<string>();
                if (string.IsNullOrEmpty(usuario.Nome) || string.IsNullOrWhiteSpace(usuario.Nome) || usuario.Nome.Length < 2)
                {
                    erros.Add("Nome inválido");
                }


                //var obrigatorios = new List<string>() {"@", "!", "#", "$", "?", "@", "1", "2", "3", "4", "5", "6", "7", "8", "9" };
                
                if (string.IsNullOrEmpty(usuario.Senha) || string.IsNullOrWhiteSpace(usuario.Senha) 
                    || usuario.Senha.Length < 4 && Regex.IsMatch(usuario.Senha, "[a-zA-Z0-9]+", RegexOptions.IgnoreCase)) //obrigatorios.Any(e => usuario.Senha.Contains(e)))
                {
                    erros.Add("Senha inválida");

                }

                Regex regex = new Regex(@"^([\w\.\-\+\D]+)@([\w\-]+)((\.(\w){2,4})+)$");
                if (string.IsNullOrEmpty(usuario.Email) || string.IsNullOrWhiteSpace(usuario.Email)
                  ||  !regex.Match(usuario.Email).Success)
                {
                    erros.Add("Email inválido");
                }

                if (erros.Count > 0)
                {
                    return BadRequest(new ErroRespostaDto()
                    {
                        Status = StatusCodes.Status400BadRequest,
                        Erros = erros
                    });
                }

                return Ok(usuario);

            }
            catch(Exception e)
            {
                _logger.LogError("Ocorreu erro ao salvar usuário", e);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status500InternalServerError,
                    Erro = "Ocorreu erro ao efetuar login, tente novamente!"
                });
            }
        }
    }
}
