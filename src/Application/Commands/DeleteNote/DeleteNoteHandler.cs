namespace Sample.Application.Commands.DeleteNote;

public sealed class DeleteNoteHandler : BaseService<Messages>, IRequestHandler<DeleteNoteCommand, TResponse<DeleteNoteResponse>>
{
    private readonly INoteService _notes;

    public DeleteNoteHandler(INoteService notes, IStringLocalizer<Messages> localizer) : base(localizer)
    {
        _notes = notes;
    }

    public async Task<TResponse<DeleteNoteResponse>> Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _notes.DeleteAsync(request.Id, cancellationToken);
        if (!deleted)
            return await FailAsync<DeleteNoteResponse>(StatusCodes.NoteNotFound);

        return await OkAsync(
            new DeleteNoteResponse(request.Id),
            StringLocalizer[StatusCodes.NoteDeleted]);
    }
}
