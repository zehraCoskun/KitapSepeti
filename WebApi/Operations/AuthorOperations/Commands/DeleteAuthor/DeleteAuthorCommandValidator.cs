using FluentValidation;

namespace WebApi.Operations.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorCommandValidator()
        {
            RuleFor(command => command.id).NotEmpty().GreaterThan(0);
        }
    }
}