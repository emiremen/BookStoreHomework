using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.BookOperations.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(command=>command.BookModel.GenreId).GreaterThan(0);
            RuleFor(command=>command.BookModel.PageCount).GreaterThan(0);
            RuleFor(command=>command.BookModel.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command=>command.BookModel.Title).NotEmpty().MinimumLength(4);
        }
    }
}