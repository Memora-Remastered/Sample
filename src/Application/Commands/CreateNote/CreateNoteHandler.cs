namespace Sample.Application.Commands.CreateNote;

public sealed class CreateNoteHandler : BaseService<Messages>, IRequestHandler<CreateNoteCommand, TResponse<CreateNoteResponse>>
{
    private readonly INoteService _notes;

    public CreateNoteHandler(INoteService notes, IStringLocalizer<Messages> localizer) : base(localizer)
    {
        _notes = notes;
    }

    public async Task<TResponse<CreateNoteResponse>> Handle(CreateNoteCommand request, CancellationToken cancellationToken)
    {
        var dto = await _notes.CreateAsync(request.Title, request.Content, cancellationToken);
        return await OkAsync(
            new CreateNoteResponse(dto.Id, dto.Title, dto.Content),
            StringLocalizer[StatusCodes.NoteCreated]);
    }
}
