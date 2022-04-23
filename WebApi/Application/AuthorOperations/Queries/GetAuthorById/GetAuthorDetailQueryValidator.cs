using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.AuthorOperations.Queries.GetAuthorById
{
    public class GetAuthorDetailQueryValidator : AbstractValidator<GetAuthorDetailQuery>
    {
        public GetAuthorDetailQueryValidator()
        {
            RuleFor(a=>a.AuthorId).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}