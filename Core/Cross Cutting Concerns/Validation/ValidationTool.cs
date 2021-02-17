using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Cross_Cutting_Concerns.Validation
{
    public static class ValidationTool
    {
        //gidip kullandığımız fluent validation da önce Interface aradık ve sonra validator
        public static void Validate(IValidator validator,object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }

        }

    }
}
