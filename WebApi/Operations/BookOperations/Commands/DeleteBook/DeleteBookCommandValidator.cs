using FluentValidation;

namespace WebApi.Operations.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommandValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command=> command.id).GreaterThan(0);
        }
    }

}