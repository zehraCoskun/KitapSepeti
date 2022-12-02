using FluentValidation;

namespace WebApi.Operations.BookOperations.Queries
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(query => query.id).NotEmpty().GreaterThan(0);
        }
    }
}