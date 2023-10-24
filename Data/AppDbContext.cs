using Microsoft.EntityFrameworkCore;
using MiniTodo.Models;

namespace MiniTodo.Data;

public class AppDbContext : DbContext
{
    public DbSet<Todo>? Todos { get; set; }

    protected readonly IConfiguration Configuration;

    public AppDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql(Configuration.GetConnectionString("WebApiDatabase"));

}