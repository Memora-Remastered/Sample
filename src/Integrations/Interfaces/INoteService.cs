namespace Sample.Integrations.Interfaces;

public interface INoteService
{
    Task<NoteDto> CreateAsync(string title, string content, CancellationToken cancellationToken);

    Task<NoteDto?> GetAsync(Guid id, CancellationToken cancellationToken);

    Task<PagingResponse<NoteDto>> ListAsync(int page, int pageSize, CancellationToken cancellationToken);

    Task<NoteDto?> UpdateAsync(Guid id, string title, string content, CancellationToken cancellationToken);

    Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
