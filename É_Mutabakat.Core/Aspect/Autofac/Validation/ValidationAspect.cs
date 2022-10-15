using Castle.DynamicProxy;
using E_Mutabakat.Core.CrossCuttingConcerns.Validation;
using E_Mutabakat.Core.Ultilities.InterCeptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mutabakat.Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterCeption
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("hatali tip");
            }
            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entitytype = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t=>t.GetType()==entitytype);
            foreach (var entty in entities)
            {
                ValidationTool.Validate(validator,entty);
            }
        }
    }
}