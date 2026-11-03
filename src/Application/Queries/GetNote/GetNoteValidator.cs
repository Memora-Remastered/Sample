namespace Sample.Application.Queries.GetNote;

public sealed class GetNoteValidator : AbstractValidator<GetNoteRequest>
{
    public GetNoteValidator()
    {
        RuleFor(request => request.Id)
            .NotEmpty();
    }
}
