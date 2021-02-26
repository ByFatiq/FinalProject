using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ValidationException = FluentValidation.ValidationException;

// İş Katmanı Somut Sınıfı
namespace Business.Concrete
{



    public class ProductManager : IProductService 

    {// İş kodları varsa;

        IProductDal _productDal;//Dependency Injection - Burada bunu yapmamızın sebebi DateAcess Layer katmanı ile haberleştirmek. 
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal, ICategoryService categoryService) // Soyut nesne ile bağlantı kuruyoruz.
        {
            _productDal = productDal;
            _categoryService = categoryService; 

        }


        public IDataResult<List<Product>> GetAll()
        {
            //İş Kodları
            //Yetkisi var mı gibi kodlar yazılır.
            //if kodları burada yer alır.

            if (DateTime.Now.Hour == 03)
            //Maintenance Time > Bakım Zamanı
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed); //Eğer iş kodlarından geçiyorsa Veri tabanına gidiyor ve
                                                                                                       //iş kodlarından geçtiği için datayı date access veri aktarıyor.

        }

        public IDataResult<List<Product>> GetAllByCategoryId(int Id) // CategoryId 'ye göre getir.
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == Id));
        }
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max) // Fiyat aralığı min - max değerleri getirir.
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            if (DateTime.Now.Hour == 19)
            //Maint1enance Time > Bakım Zamanı
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }



        [ValidationAspect(typeof(ProductValitador))] //Doğrulama Kodu Aspect Tarafından burada yapılıyor.


         
        public IResult Add(Product product)
        {
            //business Codes;


           IResult result = BussinessRules.Run(CheckIfProductNameExists(product.ProductName), 
               CheckIfProductCountOfCategoryCorrect(product.CategoryId), CheckIfCategoryLimitExceeded()); 
            
           if (result !=null)
           {
               return result;
           }
           
           return new SuccessResult(Messages.ProductAdded);

        }

        public IResult Update(Product product)
        {
            throw new NotImplementedException();
        }


        private IResult CheckIfProductCountOfCategoryCorrect(int categoryId)
        {// Select Count(*) from products where gategoryId=1
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountofCategoryError);
            }

            return new SuccessResult();
        }


        private IResult CheckIfProductNameExists(string productName)
        {// Select Count(*) from products where gategoryId=1
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }

            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceeded()
        {// Select Count(*) from products where gategoryId=1
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceeded);
            }

            return new SuccessResult();
        }
    }
}
