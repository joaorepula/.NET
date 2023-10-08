using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;


namespace API
{
    [ApiController]
    [Route("api/emprestimo")]
    public class EmprestimoController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public EmprestimoController(AppDataContext ctx)
        {
            _ctx = ctx;
        }


        [HttpGet]
        [Route("listar")]
        public IActionResult Listar()
        {
            try
            {
                List<Livro> livros = _ctx.Livros.ToList();
                return livros.Count == 0 ? NotFound() : Ok(livros);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("buscar/{id}")]
        public IActionResult Buscar(int id)
        {
            try
            {
                Livro? livroEncontrado = _ctx.Livros.FirstOrDefault(x => x.LivroId == id);
                if (livroEncontrado != null)
                {
                    return Ok(livroEncontrado);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPost]
        [Route("cadastrar")]
        public IActionResult Cadastrar([FromBody] Emprestimo emprestimo)
        {
            try
            {
                Livro livroEncontrado = _ctx.Livros.FirstOrDefault(x => x.LivroId == emprestimo.LivroId);

                if (livroEncontrado != null && livroEncontrado.Estoque > 0)
                {
                    int estoque = livroEncontrado.Estoque - 1;

                    livroEncontrado.Autor = livroEncontrado.Autor;
                    livroEncontrado.TotalPaginas = livroEncontrado.TotalPaginas;
                    livroEncontrado.Titulo = livroEncontrado.Titulo;
                    livroEncontrado.Descricao = livroEncontrado.Descricao;
                    livroEncontrado.Estoque = estoque;

                    _ctx.SaveChanges();

                    Usuario usuario = _ctx.Usuarios.FirstOrDefault(x => x.UsuarioId == emprestimo.UsuarioId);
                    if (usuario != null && usuario.Ativo == 1)
                    {
                        emprestimo.DataEmprestimo = DateTime.Now;
                        emprestimo.DataFinal = DateTime.Now.AddDays(7);

                        _ctx.Emprestimo.Add(emprestimo);
                        _ctx.SaveChanges();

                        return Created("", emprestimo);
                    }else {
                        return BadRequest("Usuário se encontra bloqueado!.");
                    }
                }
                return BadRequest("Livro não encontrado ou sem estoque disponível.");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpPut]
        [Route("atualizar/{id}")]
        public IActionResult Atualizar(int id, [FromBody] Livro livroAtualizado)
        {
            try
            {
                Livro livroExistente = _ctx.Livros.Find(id) ?? throw new InvalidOperationException($"Livro com id {id} não encontrado");

                if (livroExistente != null)
                {
                    livroExistente.Autor = livroAtualizado.Autor;
                    livroExistente.TotalPaginas = livroAtualizado.TotalPaginas;
                    livroExistente.Titulo = livroAtualizado.Titulo;
                    livroExistente.Descricao = livroAtualizado.Descricao;

                    _ctx.SaveChanges();

                    return Ok(livroExistente);
                }

                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("deletar/{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                Livro? livroEncontrado = _ctx.Livros.Find(id);
                if (livroEncontrado != null)
                {
                    _ctx.Livros.Remove(livroEncontrado);
                    _ctx.SaveChanges();
                    return Ok();
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
