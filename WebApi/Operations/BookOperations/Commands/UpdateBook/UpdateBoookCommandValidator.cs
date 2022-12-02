using FluentValidation;

namespace WebApi.Operations.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.id).GreaterThan(0).NotEmpty();
            RuleFor(command => command.Model.AuthorID).GreaterThan(0).NotEmpty();
            RuleFor(command => command.Model.GenreID).GreaterThan(0).NotEmpty();
            RuleFor(command => command.Model.PageCount).GreaterThan(0).NotEmpty();
            RuleFor(command => command.Model.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).MinimumLength(1).NotEmpty();

        }
    }
}