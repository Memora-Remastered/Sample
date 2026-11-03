namespace Sample.Controllers;

[Route("api/v1/notes")]
public sealed class NotesController : ApiBaseController
{
    [HttpGet]
    public Task<TResponse<PagingResponse<NoteDto>>> List([FromQuery] ListNotesRequest request) => SendAsync(request);

    [HttpGet("{id:guid}")]
    public Task<TResponse<GetNoteResponse>> Get(Guid id) => SendAsync(new GetNoteRequest { Id = id });

    [HttpPost]
    public Task<TResponse<CreateNoteResponse>> Create([FromBody] CreateNoteCommand command) => SendAsync(command);

    [HttpPut("{id:guid}")]
    public Task<TResponse<UpdateNoteResponse>> Update(Guid id, [FromBody] UpdateNoteCommand command)
    {
        command.Id = id;
        return SendAsync(command);
    }

    [HttpDelete("{id:guid}")]
    public Task<TResponse<DeleteNoteResponse>> Delete(Guid id) => SendAsync(new DeleteNoteCommand { Id = id });
}
