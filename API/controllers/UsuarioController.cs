using API.Data;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public UsuarioController(AppDataContext ctx)
    {
        _ctx = ctx;
    }
    [HttpGet]
    [Route("listar")]

    public IActionResult Listar()
    {
        try
        {
            List<Usuario> usuarios = _ctx.Usuarios.ToList();
            return usuarios.Count == 0 ? NotFound() : Ok(usuarios);


        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    [HttpGet]
    [Route("buscar/{nome}/{cpf}")]


    public IActionResult Buscar([FromRoute] string nome, [FromRoute] string cpf)
    {
        try
        {
            Usuario? usuarioCadastrado = _ctx.Usuarios.FirstOrDefault(x => x.Nome == nome);
            if (usuarioCadastrado != null)
            {
                return Ok(usuarioCadastrado);
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
    public IActionResult Deletar([FromRoute] int id)
    {
        try
        {
            Usuario? usuarioCadastrado = _ctx.Usuarios.Find(id);
            if (usuarioCadastrado != null)
            {
                _ctx.Usuarios.Remove(usuarioCadastrado);
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







