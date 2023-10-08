using API.Models; // Certifique-se de ter o namespace correto

namespace API
{
    public class Emprestimo
    {
        public int EmprestimoId { get; set; }

        public Livro? Livro { get; set; }
        public int LivroId { get; set; }
        public Usuario? Usuario { get; set; }
        public int UsuarioId { get; set; } 
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataFinal { get; set; }

        public Emprestimo()
        {
            DataEmprestimo = DateTime.Now;
        }

    }
}
