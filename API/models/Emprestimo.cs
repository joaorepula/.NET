namespace API;

    public class Emprestimo
    {
        public int EmprestimoId { get; set; } // Id do empréstimo (pode ser gerado automaticamente pelo banco de dados)
        public int LivroId { get; set; } // Chave estrangeira para o livro emprestado
        public int UserId { get; set; } // Chave estrangeira para o usuário que fez o empréstimo
        public DateTime DataEmprestimo { get; set; } // Data de empréstimo

        public DateTime DataFinal { get; set; } // Data final do empréstimo

        public Emprestimo()
        {
            DataEmprestimo = DateTime.Now; // Configura DataEmprestimo com DateTime.Now ao criar um novo empréstimo
        }

        // Outros métodos, propriedades ou construtores podem ser adicionados conforme necessário
    }








