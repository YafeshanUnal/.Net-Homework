using FluentValidation;
using Webapi.BookOperations.GetBookDetail;
namespace WebApi.BookOperations
{

    public class GetBookDetailQueryValidator : AbstractValidator<GetBookDetailQuery>
    {
        public GetBookDetailQueryValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}