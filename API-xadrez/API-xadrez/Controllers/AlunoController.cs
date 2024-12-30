using API_xadrez.DTOs;
using API_xadrez.Entities;
using API_xadrez.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_xadrez.Controllers;

[ApiController]
[Route("api/[controller]")]

public class AlunoController : Controller
{
    private readonly IAlunoService _alunoService;

    public AlunoController(IAlunoService alunoService)
    {
        _alunoService = alunoService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarTodosAlunos()
    {
        try
        {
            var alunos = await _alunoService.GetAllAsync();
            return Ok(alunos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno ao listar alunos.", Detalhes = ex.Message });
        }
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> ListarPorId(int id)
    {
        try
        {
            var alunos = await _alunoService.PesquisarPorId(id);

            if (alunos == null)
            {
                return NotFound(new { Message = $"Alunos com id {id} não encontrado." });
            }
            return Ok(alunos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno ao buscar Aluno.", Detalhes = ex.Message });
        }

    }
    [HttpPost]
    public async Task<IActionResult> AdicionarAluno([FromBody] Aluno aluno)
    {
        try
        {
            if (aluno == null)
            {
                return BadRequest(new { Message = "Dados inválidos para cadastrar o aluno" });
            }
            await _alunoService.AdicionarAsync(aluno);
            return CreatedAtAction(nameof(ListarPorId), new { id = aluno.Id }, aluno);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno ao adicionar aluno.", Detalhes = ex.Message });
        }
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizaAluno(int id, [FromBody] AtualizarAlunoDTO alunoDTO)
    {
        try
        {
            var alunoExistente = await _alunoService.PesquisarPorId(id);
            if (alunoExistente == null)
            {
                return NotFound(new { Message = "Aluno não encontrado" });
            }

            if (!string.IsNullOrWhiteSpace(alunoDTO.Nome))
            {
                alunoExistente.Nome = alunoDTO.Nome;
            }

            alunoExistente.Ponto = alunoDTO.Ponto;
            alunoExistente.UpdatedAt = DateTime.Now;

            await _alunoService.AlterarAsync(alunoExistente);

            return Ok("Aluno atualizado com sucesso!");
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno ao atualizar aluno.", Detalhes = ex.Message });
        }
    }
    [HttpDelete]
    public async Task<IActionResult> ExcluirAluno(int id)
    {
        try
        {
            await _alunoService.ExcluirAsync(id);
            return Ok("Aluno excluído com sucesso");
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "Erro interno ao excluir presente.", Detalhes = ex.Message });
        }

    }
}
