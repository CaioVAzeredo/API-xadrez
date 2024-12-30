using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace API_xadrez.Entities;
[Table("tb_aluno")]
public class Aluno
{
    [Column("id")]
    public int Id { get; set; }
    public string? Nome { get; set; }
    public float Ponto { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}
