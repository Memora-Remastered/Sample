namespace Sample.Application.Queries.GetNote;

public sealed class GetNoteHandler : BaseService<Messages>, IRequestHandler<GetNoteRequest, TResponse<GetNoteResponse>>
{
    private readonly INoteService _notes;

    public GetNoteHandler(INoteService notes, IStringLocalizer<Messages> localizer) : base(localizer)
    {
        _notes = notes;
    }

    public async Task<TResponse<GetNoteResponse>> Handle(GetNoteRequest request, CancellationToken cancellationToken)
    {
        var dto = await _notes.GetAsync(request.Id, cancellationToken);
        if (dto is null)
            return await FailAsync<GetNoteResponse>(StatusCodes.NoteNotFound);

        return await OkAsync(new GetNoteResponse(dto.Id, dto.Title, dto.Content));
    }
}
