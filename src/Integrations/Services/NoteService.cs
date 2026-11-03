namespace Sample.Integrations.Services;

public sealed class NoteService(Client supabaseClient, PaginationConfigs pagination, IRequestContextAccessor request) : INoteService
{
    private readonly Client _supabaseClient = supabaseClient;
    private readonly PaginationConfigs _pagination = pagination;
    private readonly IRequestContextAccessor _request = request;

    public async Task<NoteDto> CreateAsync(string title, string content, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            Id = Guid.NewGuid(),
            Title = title,
            Content = content
        };

        var response = await _supabaseClient
            .From<Note>()
            .Insert(note, cancellationToken: cancellationToken);

        return ToDto(response.Models[0]);
    }

    public async Task<NoteDto?> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        var response = await _supabaseClient
            .From<Note>()
            .Where(note => note.Id == id)
            .Limit(1)
            .Get(cancellationToken);

        var note = response.Models.FirstOrDefault();
        return note is null ? null : ToDto(note);
    }

    public async Task<PagingResponse<NoteDto>> ListAsync(int page, int pageSize, CancellationToken cancellationToken)
    {
        (page, pageSize) = _pagination.Clamp(page, pageSize);
        var offset = (page - 1) * pageSize;

        var response = await _supabaseClient
            .From<Note>()
            .Range(offset, offset + pageSize - 1)
            .Get(cancellationToken, Supabase.Postgrest.Constants.CountType.Exact);

        var rows = response.Models.ConvertAll(ToDto);
        return new PagingResponse<NoteDto>(rows, response.Count, page, pageSize, _request.Current.RequestUrl);
    }

    public async Task<NoteDto?> UpdateAsync(Guid id, string title, string content, CancellationToken cancellationToken)
    {
        var note = new Note
        {
            Id = id,
            Title = title,
            Content = content
        };

        var response = await _supabaseClient
            .From<Note>()
            .Where(row => row.Id == id)
            .Update(note, cancellationToken: cancellationToken);

        var updated = response.Models.FirstOrDefault();
        return updated is null ? null : ToDto(updated);
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var existing = await GetAsync(id, cancellationToken);
        if (existing is null)
            return false;

        _ = await _supabaseClient
            .From<Note>()
            .Where(note => note.Id == id)
            .Delete(cancellationToken: cancellationToken);

        return true;
    }

    private static NoteDto ToDto(Note note) => new(note.Id, note.Title, note.Content);
}
