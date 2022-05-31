using FluentValidation;
using WebApi.Application.GenreOperations.Command.UpdateAuthors;

namespace WebApi.Application.AuthorOperations.Command.UpdateAuthors
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(command => command.Model.Name).MinimumLength(5).MaximumLength(50);
        }
    }
}