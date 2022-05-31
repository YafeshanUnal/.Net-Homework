using FluentValidation;
namespace WebApi.Application.AuthorOperations.Command.DeleteAuthors
{
    public class DeleteAuthorsCommandValidator : AbstractValidator<DeleteAuthorCommand>
    {
        public DeleteAuthorsCommandValidator()
        {
            RuleFor(command => command.AuthorId).GreaterThan(0);
        }
    }
}