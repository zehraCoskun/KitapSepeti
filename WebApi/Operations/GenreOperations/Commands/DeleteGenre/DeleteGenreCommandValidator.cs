using FluentValidation;

namespace WebApi.Operations.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command => command.id).NotEmpty().GreaterThan(0);
        }
    }
}