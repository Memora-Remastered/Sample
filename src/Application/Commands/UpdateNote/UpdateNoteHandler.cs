namespace Sample.Application.Commands.UpdateNote;

public sealed class UpdateNoteHandler : BaseService<Messages>, IRequestHandler<UpdateNoteCommand, TResponse<UpdateNoteResponse>>
{
    private readonly INoteService _notes;

    public UpdateNoteHandler(INoteService notes, IStringLocalizer<Messages> localizer) : base(localizer)
    {
        _notes = notes;
    }

    public async Task<TResponse<UpdateNoteResponse>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var dto = await _notes.UpdateAsync(request.Id, request.Title, request.Content, cancellationToken);
        if (dto is null)
            return await FailAsync<UpdateNoteResponse>(StatusCodes.NoteNotFound);

        return await OkAsync(
            new UpdateNoteResponse(dto.Id, dto.Title, dto.Content),
            StringLocalizer[StatusCodes.NoteUpdated]);
    }
}
