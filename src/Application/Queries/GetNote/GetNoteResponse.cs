namespace Sample.Application.Queries.GetNote;

public sealed record GetNoteResponse(Guid Id, string Title, string Content);
