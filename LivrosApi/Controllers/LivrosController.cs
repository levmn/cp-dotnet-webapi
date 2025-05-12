using LivrosBusiness;
using LivrosModel;
using Microsoft.AspNetCore.Mvc;

namespace LivrosApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LivrosController
(
    LivroService livroService
) : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var livros = livroService.ListarTodos();
        return livros.Count == 0 ? NoContent() : Ok(livros);
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        var livro = livroService.ObterPorId(id);
        return livro == null ? NotFound() : Ok(livro);
    }

    [HttpPost]
    public IActionResult Post([FromBody] LivroModel livro)
    {
        if (string.IsNullOrWhiteSpace(livro.Titulo))
            return BadRequest("O título é um campo obrigatório.");
        var criado = livroService.Criar(livro);
        return CreatedAtAction(nameof(Get), new { id = criado.Id }, criado);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] LivroModel livro)
    {
        if (livro == null || livro.Id != id)
            return BadRequest("Dados inconsistentes.");
        return livroService.Atualizar(livro) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return livroService.Remover(id) ? NoContent() : NotFound();
    }
}