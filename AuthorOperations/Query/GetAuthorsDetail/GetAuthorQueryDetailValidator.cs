using FluentValidation;

namespace WebApi.Application.AuthorOperations.Query.GetAuthorsDetail{

    public class GetAuthorQueryDetailValidator : AbstractValidator<GetAuthorQueryDetail>{

        public GetAuthorQueryDetailValidator()
        {
            RuleFor(command => command.Model.Id).GreaterThan(0);
        }
    }
}