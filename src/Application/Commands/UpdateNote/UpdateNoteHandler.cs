namespace Sample.Application.Commands.UpdateNote;

public sealed class UpdateNoteHandler(INoteService notes, IStringLocalizer<Messages> localizer) : BaseService<Messages>(localizer), IRequestHandler<UpdateNoteCommand, TResponse<UpdateNoteResponse>>
{
    public async Task<TResponse<UpdateNoteResponse>> Handle(UpdateNoteCommand request, CancellationToken cancellationToken)
    {
        var dto = await notes.UpdateAsync(request.Id, request.Title, request.Content, cancellationToken);
        if (dto is null)
            return await FailAsync<UpdateNoteResponse>(StatusCodes.NoteNotFound);

        return await OkAsync(
            new UpdateNoteResponse(dto.Id, dto.Title, dto.Content),
            StringLocalizer[StatusCodes.NoteUpdated]);
    }
}
