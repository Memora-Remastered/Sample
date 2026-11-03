namespace Sample.Application.Commands.CreateNote;

public sealed class CreateNoteCommand : IRequest<TResponse<CreateNoteResponse>>
{
    public string Title { get; set; } = "";

    public string Content { get; set; } = "";
}
