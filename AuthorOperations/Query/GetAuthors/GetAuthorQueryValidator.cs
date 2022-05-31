using FluentValidation;
namespace WebApi.Application.AuthorOperations.Query.GetAuthors{

    public class GetAuthorsQueryValidator : AbstractValidator<GetAuthorQuery>
    {
        public GetAuthorsQueryValidator()
        {
            RuleFor(command => command.Model.Id).GreaterThan(0);
        }
    }
}