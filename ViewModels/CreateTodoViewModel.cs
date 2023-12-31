using Flunt.Notifications;
using Flunt.Validations;
using MiniTodo.Models;

namespace MiniTodo.ViewModels;

public class CreateTodoViewModel : Notifiable<Notification>
{
    public string Title { get; set; } = null!;

    public bool Done { get; set; }

    public Todo MapTo()
    {
        var titleContract = new Contract<Notification>()
            .Requires()
            .IsNotNull(Title, "Informe o titúlo da tarefa")
            .IsGreaterThan(Title, 5, "O titúlo da tarefa deve ter mais de 5 caracteres");

        var doneContract = new Contract<Notification>()
            .Requires()
            .IsNotNull(Done, "Informe o status da tarefa");

        AddNotifications(titleContract);
        AddNotifications(doneContract);

        return new Todo(Guid.NewGuid(), Title, Done);
    }
}