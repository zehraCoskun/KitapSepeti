using FluentValidation;

namespace WebApi.Operations.AuthorOperations.Queries
{
    public class GetAuthorByIdQueryValidator : AbstractValidator<GetAuthorByIdQuery>
    {
        public GetAuthorByIdQueryValidator()
        {
            RuleFor(query => query.id).NotEmpty().GreaterThan(0);
        }
    }
}