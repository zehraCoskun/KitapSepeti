using FluentValidation;

namespace WebApi.Operations.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command=> command.Model.GenreID).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.AuthorID).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.PageCount).NotEmpty().GreaterThan(0);
            RuleFor(command=> command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command=> command.Model.Title).NotEmpty().MinimumLength(2);
        }
    }
}