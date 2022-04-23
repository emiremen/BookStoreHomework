using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator: AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(a=>a.AuthorId).NotEmpty().NotNull().GreaterThan(0);
            RuleFor(a=>a.AuthorModel.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(a=>a.AuthorModel.Surname).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(a=>a.AuthorModel.Birthday.Date).LessThan(DateTime.Now);
        }
    }
}