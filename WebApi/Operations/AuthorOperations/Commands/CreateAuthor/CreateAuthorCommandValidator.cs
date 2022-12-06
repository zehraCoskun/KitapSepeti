using FluentValidation;

namespace WebApi.Operations.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).NotEmpty();
            RuleFor(command => command.Model.LastName).NotEmpty();
            RuleFor(command => command.Model.DateOfBirth.Date).NotEmpty().LessThan(DateTime.Now.Date.AddYears(-10));
        }
    }
}