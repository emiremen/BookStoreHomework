using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command=>command.BookId).GreaterThan(0);
            RuleFor(command=>command.BookModel.GenreId).GreaterThan(0);
            RuleFor(command=>command.BookModel.PageCount).GreaterThan(0);
            RuleFor(command=>command.BookModel.PublishDate.Date).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command=>command.BookModel.Title).NotEmpty().MinimumLength(4);
            RuleFor(command=>command.BookModel.IsPublished).NotNull();
        }
    }
}