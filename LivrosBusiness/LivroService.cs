using LivrosModel;
using System.Collections.Generic;
using System.Linq;

namespace LivrosBusiness;
public class LivroService
{
    private static readonly List<LivroModel> _livros = new();
    private static int _nextId = 1;

    public List<LivroModel> ListarTodos() => _livros;
    public LivroModel? ObterPorId(int id) => _livros.FirstOrDefault(c => c.Id == id);

    public LivroModel Criar(LivroModel livro)
    {
        livro.Id = _nextId++;
        _livros.Add(livro);
        return livro;
    }
  
    public bool Atualizar(LivroModel livro)
    {
        var existente = ObterPorId(livro.Id);
        if (existente == null) return false;
        existente.Titulo = livro.Titulo;
        existente.Autor = livro.Autor;
        existente.Genero = livro.Genero;
        existente.AnoPublicacao = livro.AnoPublicacao;
        return true;
    }

    public bool Remover(int id)
    {
        var livro = ObterPorId(id);
        if (livro == null) return false;
        _livros.Remove(livro);
        return true;
    }
}
