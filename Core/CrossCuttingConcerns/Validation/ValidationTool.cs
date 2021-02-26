using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)//Bir IValitator geliyor Örn; ProductValidator birde bir varlık geliyor Product.
        {
            var context = new ValidationContext<object>(entity);

            var result = validator.Validate(context);// Kurallar için ilgili kontexti doğrula
            if (!result.IsValid)// sonuç doğru değilse hata fırlat.
            {
                throw new ValidationException(result.Errors);
            }
        }


         


    }
}
