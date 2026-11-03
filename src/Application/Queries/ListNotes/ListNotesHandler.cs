namespace Sample.Application.Queries.ListNotes;

public sealed class ListNotesHandler : BaseService<Messages>, IRequestHandler<ListNotesRequest, TResponse<PagingResponse<NoteDto>>>
{
    private readonly INoteService _notes;

    public ListNotesHandler(INoteService notes, IStringLocalizer<Messages> localizer) : base(localizer)
    {
        _notes = notes;
    }

    public async Task<TResponse<PagingResponse<NoteDto>>> Handle(ListNotesRequest request, CancellationToken cancellationToken)
    {
        var page = await _notes.ListAsync(request.Page, request.PageSize, cancellationToken);
        return await OkAsync(page);
    }
}
