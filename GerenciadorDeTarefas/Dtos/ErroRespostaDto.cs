namespace GerenciadorDeTarefas.Dtos
{
    public class ErroRespostaDto
    {
        public int Status { get; set; }
        public string Erro { get; set; }
        public List<string> Erros { get; set; }
    }
}
