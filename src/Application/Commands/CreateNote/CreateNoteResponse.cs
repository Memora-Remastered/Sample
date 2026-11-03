namespace Sample.Application.Commands.CreateNote;

public sealed record CreateNoteResponse(Guid Id, string Title, string Content);
