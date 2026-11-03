namespace Sample.Application.Commands.DeleteNote;

public sealed class DeleteNoteCommand : IRequest<TResponse<DeleteNoteResponse>>
{
    public Guid Id { get; set; }
}
