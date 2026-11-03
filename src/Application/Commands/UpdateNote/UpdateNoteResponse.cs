namespace Sample.Application.Commands.UpdateNote;

public sealed record UpdateNoteResponse(Guid Id, string Title, string Content);
