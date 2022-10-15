using System;
using FluentValidation;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Mutabakat.Entities.Concrete;

namespace E_Mutabakat.Business.ValidationRules.FluentValidation
{
   public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("kullanıcı adı boş olamaz");
            RuleFor(p => p.Name).NotEmpty().WithMessage("kullanıcı adı boş olamaz");
            RuleFor(p => p.Name).MinimumLength(4).WithMessage("kullanıcı adı en az 4 karakter olmalı");
            RuleFor(p => p.Email).NotEmpty().WithMessage("Email adresi boş olamaz");
            RuleFor(p => p.Email).EmailAddress().WithMessage("geçerli bir email adresi yazin");

        }

    }
}
