using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using System.Text;
using System.Threading.Tasks;
using E_Mutabakat.Entities.Concrete;

namespace E_Mutabakat.Business.ValidationRules.FluentValidation
{
    public class CompanyValidator:AbstractValidator<Company>
    {
        public CompanyValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("sirket ismi bos olamaz");
            RuleFor(p => p.Name).MinimumLength(4).WithMessage("sirket ismi en az 4 karakter olmalı");
            RuleFor(p => p.Address).NotEmpty().WithMessage("sirket adresi bos olamaz");
        }
    }
}
