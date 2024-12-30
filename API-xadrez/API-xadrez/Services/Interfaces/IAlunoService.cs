using API_xadrez.Entities;

namespace API_xadrez.Services.Interfaces;

public interface IAlunoService
{
    Task AdicionarAsync(Aluno aluno);
    Task AlterarAsync(Aluno aluno);
    Task ExcluirAsync(int id);
    Task<Aluno> PesquisarPorId(int id);
    Task<IEnumerable<Aluno>> GetAllAsync();

}
