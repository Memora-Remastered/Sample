namespace Sample.Application.Queries.GetNote;

public sealed class GetNoteRequest : IRequest<TResponse<GetNoteResponse>>
{
    public Guid Id { get; set; }
}
