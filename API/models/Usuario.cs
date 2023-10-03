using System;

namespace API.Models
{
    public class Usuario
    {   
        public int UsuarioId { get; set; } // Id do usuário (pode ser gerado automaticamente pelo banco de dados)
        public string? Nome { get; set; } // Nome do usuário
        public string? CPF { get; set; } // CPF do usuário
        public string? Endereco { get; set; } // Endereço do usuário
        public string? Senha { get; set; } // Senha do usuário (certifique-se de criptografá-la adequadamente)
        public string? Telefone { get; set; } // Número de telefone do usuário
        public bool Ativo { get; set; } // Indica se o usuário está ativo ou não

        // Outros métodos, propriedades ou construtores podem ser adicionados conforme necessário
    }
}

