using FluentValidation;

namespace WebApi.Operations.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command => command.id).NotEmpty().GreaterThan(0);
            RuleFor(command => command.Model.GenreName).MinimumLength(2).When(x=> x.Model.GenreName.Trim() != string.Empty);
        }
    }
}