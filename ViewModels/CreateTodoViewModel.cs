using Flunt.Notifications;
using Flunt.Validations;
using MiniTodo.Models;

namespace MiniTodo.ViewModels;

public abstract class CreateTodoViewModel : Notifiable<Notification>
{
    private string Title { get; } = null!;

    public Todo MapTo()
    {
        var contract = new Contract<Notification>()
            .Requires()
            .IsNotNull(Title, "Informe o titúlo da tarefa")
            .IsGreaterThan(Title, 5, "O titúlo da tarefa deve ter mais de 5 caracteres");

        AddNotifications(contract);

        return new Todo(Guid.NewGuid(), Title, false);
    }
}