namespace Sample.Application.Queries.GetNote;

public sealed class GetNoteHandler(INoteService notes, IStringLocalizer<Messages> localizer) : BaseService<Messages>(localizer), IRequestHandler<GetNoteRequest, TResponse<GetNoteResponse>>
{
    public async Task<TResponse<GetNoteResponse>> Handle(GetNoteRequest request, CancellationToken cancellationToken)
    {
        var dto = await notes.GetAsync(request.Id, cancellationToken);
        if (dto is null)
            return await FailAsync<GetNoteResponse>(StatusCodes.NoteNotFound);

        return await OkAsync(new GetNoteResponse(dto.Id, dto.Title, dto.Content));
    }
}
