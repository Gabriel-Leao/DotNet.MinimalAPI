using Microsoft.EntityFrameworkCore;

namespace MiniTodo.Data;

public class AppDbContext : DbContext
{
    public DbSet<Todo> Todos { get; set; }
    private string server = Environment.GetEnvironmentVariable("SERVER");
    private string user = Environment.GetEnvironmentVariable("USER");
    private string db = Environment.GetEnvironmentVariable("DB");
    private string password = Environment.GetEnvironmentVariable("PASS");

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySQL($"server={server};database={db};user={user};password={password}");

}