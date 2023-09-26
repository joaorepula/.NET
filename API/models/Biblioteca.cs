namespace API.Models;

public class Biblioteca
{
        public int BibliotecaId { get; set; } // Id da biblioteca (pode ser gerado automaticamente pelo banco de dados)
        public int UserId { get; set; } // Id do usuário associado à biblioteca
        public string? BibliotecaNome  { get; set; } // Nome da biblioteca
        public string? BibliotecaEndereco { get; set; } // Endereço da biblioteca


}
