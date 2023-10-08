using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;


namespace API
{
    [ApiController]
    [Route("api/livro")]
    public class LivroController : ControllerBase
    {
        private readonly AppDataContext _ctx;

        public LivroController(AppDataContext ctx)
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
        public IActionResult Cadastrar([FromBody] Livro livro)
        {
            try
            {
                _ctx.Livros.Add(livro);
                _ctx.SaveChanges();
                return Created("", livro);
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
