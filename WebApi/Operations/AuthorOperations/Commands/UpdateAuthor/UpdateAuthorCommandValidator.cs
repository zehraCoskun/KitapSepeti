using FluentValidation;

namespace WebApi.Operations.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.FirstName).NotEmpty();
            RuleFor(command => command.Model.LastName).NotEmpty();
            RuleFor(command => command.Model.DateOfBirth.Date).NotEmpty().LessThan(DateTime.Now.Date);
        }
    }
}