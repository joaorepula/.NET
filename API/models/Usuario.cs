using System;

namespace API.Models
{
    public class Usuario
    {   
        public int UsuarioId { get; set; }
        public string? Nome { get; set; } 
        public string? CPF { get; set; } 
        public string? Endereco { get; set; } 
        public string? Senha { get; set; } 
        public string? Telefone { get; set; } 
        public int Ativo { get; set; }

    }
}

