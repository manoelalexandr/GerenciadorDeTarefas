using GerenciadorDeTarefas.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeTarefas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult EfetuarLogin([FromBody] LoginRequisicaoDto requisicao)
        {
            try
            {

            } 
            catch(Exception excecao)
            {
                _logger.LogError("Ocorreu erro ao efetuar login", excecao, requisicao);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErroRespostaDto()
                {
                    Status = StatusCodes.Status500InternalServerError, 
                    Erro = "Ocorreu erro ao efetuar login, tente novamente!"
                });

            }
        }
    }
}
