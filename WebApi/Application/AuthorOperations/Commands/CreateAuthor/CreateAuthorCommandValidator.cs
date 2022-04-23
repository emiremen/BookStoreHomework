using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(command=>command.authorModel.Name).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(command=>command.authorModel.Surname).NotEmpty().NotNull().MinimumLength(3);
            RuleFor(command=>command.authorModel.Birthday.Date).NotEmpty().NotNull().LessThan(DateTime.Now.Date);
        }
    }
}