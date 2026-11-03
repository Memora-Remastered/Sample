namespace Sample.Application.Commands.DeleteNote;

public sealed class DeleteNoteValidator : AbstractValidator<DeleteNoteCommand>
{
    public DeleteNoteValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty();
    }
}
