namespace Sample.Application.Commands.DeleteNote;

public sealed class DeleteNoteHandler(INoteService notes, IStringLocalizer<Messages> localizer) : BaseService<Messages>(localizer), IRequestHandler<DeleteNoteCommand, TResponse<DeleteNoteResponse>>
{
    public async Task<TResponse<DeleteNoteResponse>> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var deleted = await notes.DeleteAsync(request.Id, cancellationToken);
        if (!deleted)
            return await FailAsync<DeleteNoteResponse>(StatusCodes.NoteNotFound);

        return await OkAsync(
            new DeleteNoteResponse(request.Id),
            StringLocalizer[StatusCodes.NoteDeleted]);
    }
}
