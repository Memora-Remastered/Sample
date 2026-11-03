namespace Sample.Application.Commands.CreateNote;

public sealed class CreateNoteHandler(INoteService notes, IStringLocalizer<Messages> localizer) : BaseService<Messages>(localizer), IRequestHandler<CreateNoteCommand, TResponse<CreateNoteResponse>>
{
    public async Task<TResponse<CreateNoteResponse>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var dto = await notes.CreateAsync(request.Title, request.Content, cancellationToken);
        return await OkAsync(
            new CreateNoteResponse(dto.Id, dto.Title, dto.Content),
            StringLocalizer[StatusCodes.NoteCreated]);
    }
}
