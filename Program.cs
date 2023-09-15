using MiniTodo.Data;
using MiniTodo.Models;
using MiniTodo.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

DotNetEnv.Env.Load();

app.MapGet("/", context =>
{
    context.Response.Redirect("/todos");
    return Task.FromResult(0);
});

app.MapGet("/todos", (AppDbContext context) =>
{
    var todos = context.Todos!.ToList();
    return Results.Ok(todos);
}).Produces<Todo>();

app.MapGet("/todos/{id:guid}", (Guid id, AppDbContext context) =>
{
    var todo = context.Todos?.SingleOrDefault(todo => todo.Id == id);

    return todo == null ? Results.NotFound("Tarefa não encontrada") : Results.Ok(todo);
}).Produces<Todo>();

app.MapPost("todos", (AppDbContext context, CreateTodoViewModel model) =>
{
    var todo = model.MapTo();
    if (!model.IsValid)
        return Results.BadRequest(model.Notifications);
    context.Todos!.Add(todo);
    context.SaveChanges();

    return Results.Created($"/todos/{todo.Id}", todo);
}).Produces<Todo>();

app.Run();