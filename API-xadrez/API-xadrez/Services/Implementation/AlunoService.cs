using API_xadrez.Data.Context;
using API_xadrez.Entities;
using API_xadrez.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API_xadrez.Services.Implementation;

public class AlunoService : IAlunoService
{
    private readonly MySQLContext _context;

    public AlunoService(MySQLContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Aluno aluno)
    {
        await _context.Aluno.AddAsync(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task AlterarAsync(Aluno aluno)
    {
        _context.Aluno.Update(aluno);
        await _context.SaveChangesAsync();
    }

    public async Task ExcluirAsync(int id)
    {
        var aluno = await _context.Aluno.FindAsync(id);
        if (aluno != null)
        {
            _context.Aluno.Remove(aluno);
            await _context.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<Aluno>> GetAllAsync()
    {
        return await _context.Aluno.ToListAsync();
    }

    public async Task<Aluno> PesquisarPorId(int id)
    {
        return await _context.Aluno.FirstOrDefaultAsync(a => a.Id == id);
    }

}
