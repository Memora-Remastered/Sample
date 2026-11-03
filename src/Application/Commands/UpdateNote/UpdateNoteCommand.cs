namespace Sample.Application.Commands.UpdateNote;

public sealed class UpdateNoteCommand : IRequest<TResponse<UpdateNoteResponse>>
{
    public Guid Id { get; set; }

    public string Title { get; set; } = "";

    public string Content { get; set; } = "";
}
