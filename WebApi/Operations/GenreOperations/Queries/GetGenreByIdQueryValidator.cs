using FluentValidation;

namespace WebApi.Operations.GenreOperations.Queries
{
    public class GetGenreByIdQueryValidator : AbstractValidator<GetGenreByIdQuery>
    {
        public GetGenreByIdQueryValidator()
        {
            RuleFor(query => query.id).NotEmpty().GreaterThan(0);
        }
    }
}