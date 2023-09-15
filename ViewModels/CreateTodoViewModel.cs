using Flunt.Notifications;
using Flunt.Validations;
using MiniTodo.Models;

namespace MiniTodo.ViewModels;

public class CreateTodoViewModel : Notifiable<Notification>
{
    public string Title { get; set; } = null!;

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