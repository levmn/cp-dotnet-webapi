using LivrosModel;
using LivrosData;
using System.Collections.Generic;
using System.Linq;

namespace LivrosBusiness;

public class LivroService
{
    private readonly LivrosDbContext _context;

    public LivroService(LivrosDbContext context)
    {
        _context = context;
    }

    public List<LivroModel> ListarTodos() =>
        _context.Livros.ToList();

    public LivroModel? ObterPorId(int id) =>
        _context.Livros.FirstOrDefault(l => l.Id == id);

    public LivroModel Criar(LivroModel livro)
    {
        Console.WriteLine(">> Criando livro no banco Oracle...");
        _context.Livros.Add(livro);
        _context.SaveChanges();
        return livro;
    }

    public bool Atualizar(LivroModel livro)
    {
        var existente = _context.Livros.Find(livro.Id);
        if (existente == null) return false;

        existente.Titulo = livro.Titulo;
        existente.Autor = livro.Autor;
        existente.Genero = livro.Genero;
        existente.AnoPublicacao = livro.AnoPublicacao;

        _context.SaveChanges();
        return true;
    }

    public bool Remover(int id)
    {
        var livro = _context.Livros.Find(id);
        if (livro == null) return false;

        _context.Livros.Remove(livro);
        _context.SaveChanges();
        return true;
    }
}
