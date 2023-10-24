using Microsoft.EntityFrameworkCore;
using MiniTodo.Models;

namespace MiniTodo.Data;

public class AppDbContext : DbContext
{
    public DbSet<Todo>? Todos { get; set; }

    private readonly string? _server = Environment.GetEnvironmentVariable("SERVER");
    private readonly string? _user = Environment.GetEnvironmentVariable("USER");
    private readonly string? _db = Environment.GetEnvironmentVariable("DB");
    private readonly string? _password = Environment.GetEnvironmentVariable("PASS");

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseNpgsql($"Host={_server};Username={_user};Password={_password};Database={_db}");

}