using FluentValidation;
using WebApi.Application.AuthorOperations.Command.CreateAuthors;

namespace WebApi.Application.AuthorOperations.Command.CreateAuthors{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>{
        public CreateAuthorCommandValidator(){
            RuleFor(command => command.Model.Name).MinimumLength(5).MaximumLength(50);
        }
    }
}