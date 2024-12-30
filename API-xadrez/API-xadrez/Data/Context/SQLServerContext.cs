using API_xadrez.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_xadrez.Data.Context;

public class MySQLContext : DbContext
{
    public MySQLContext(DbContextOptions options) : base(options){}

    public DbSet<Aluno> Aluno { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=campxadrez;User=root;Password=caio123456;",
                    new MySqlServerVersion(new Version(8, 0, 31)));
        }
    }
}
