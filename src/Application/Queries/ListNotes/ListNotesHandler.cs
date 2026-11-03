namespace Sample.Application.Queries.ListNotes;

public sealed class ListNotesHandler(INoteService notes, IStringLocalizer<Messages> localizer) : BaseService<Messages>(localizer), IRequestHandler<ListNotesRequest, TResponse<PagingResponse<NoteDto>>>
{
    public async Task<TResponse<PagingResponse<NoteDto>>> Handle(ListNotesRequest request, CancellationToken cancellationToken)
    {
        var page = await notes.ListAsync(request.Page, request.PageSize, cancellationToken);
        return await OkAsync(page);
    }
}
