using FluentValidation;
using WebApi.BookOperations.DeleteBooks;

namespace WebApi.BookOperations
{
    public class DeleteBooksCommandValidator : AbstractValidator<DeleteBooksCommand>
    {
        public DeleteBooksCommandValidator()
        {
            RuleFor(command => command.BookId).GreaterThan(0);
        }
    }
}