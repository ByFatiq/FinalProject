﻿using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ProductValitador : AbstractValidator<Product>

    {
        public ProductValitador()
        {
            RuleFor(p => p.ProductName).NotEmpty();
            RuleFor(p => p.ProductName).MinimumLength(2);
            RuleFor(p => p.UnitPrice).NotEmpty();
            RuleFor(p => p.UnitPrice).GreaterThan(0);

            RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);//İçeçek kategorisinin fiyatı 10'dan büyük olmalı


            RuleFor(p => p.ProductName).Must(StartWithA).WithMessage("Ürün İsmi A İle Başlamalı"); //Ürün ismi A harfi ile başlar



        }

        private bool StartWithA(string arg) // arg 22 deki product
        {
            return arg.StartsWith("A");
        }
    }
}
