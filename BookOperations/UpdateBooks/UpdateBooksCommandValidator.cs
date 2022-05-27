using FluentValidation;
using WebApi.BookOperations.UpdateBooks;

namespace WebApi.BookOperations
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBooksCommand>
    {

        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Model.Title).NotEmpty().MaximumLength(200);
            RuleFor(command => command.Model.GenreId).GreaterThan(0).LessThan(100); 
        }
    }
}