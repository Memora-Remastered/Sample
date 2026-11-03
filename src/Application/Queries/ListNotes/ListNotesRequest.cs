namespace Sample.Application.Queries.ListNotes;

public sealed class ListNotesRequest : IRequest<TResponse<PagingResponse<NoteDto>>>
{
    public int Page { get; set; }

    public int PageSize { get; set; }
}
