using E_Mutabakat.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Business.ValidationRules.FluentValidation
{
    public class CurrencyAccountValidator:AbstractValidator<CurrencyAccount>

    {
        public CurrencyAccountValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("firma adı boş olamaz");
            RuleFor(p => p.Name).MinimumLength(4).WithMessage("firma adı en az 4 karakter olmalıdır");
            RuleFor(p => p.Address).NotEmpty().WithMessage("firma adresi boş olamaz");
            RuleFor(p => p.Address).MinimumLength(4).WithMessage("firma adı en az 4 karakter olmalıdır");

        }
    }
}
