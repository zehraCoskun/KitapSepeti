using FluentValidation;

namespace WebApi.Operations.GenreOperations.Commands.CreatGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command => command.Model.GenreName).NotEmpty();
        }
    }
}