using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;

namespace Application.User.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty();
            RuleFor(v => v.Username).NotEmpty();
            RuleFor(v => v.Password).NotEmpty();
        }
    }
}
