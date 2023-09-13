using API.Data;
using API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace FilmesAPI.Controllers;

[ApiController]
[Route("api/produto")]
public class FilmeController : ControllerBase
{
    private AppDataContext _context;

    public FilmeController(AppDataContext context)
    {
        _context = context;
    }

    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar(
        [FromBody] Produto produto)
    {
        _context.Produtos.Add(produto);
        _context.SaveChanges();
        return Created("", produto);
    }


}