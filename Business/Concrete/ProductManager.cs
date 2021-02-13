﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

// İş Katmanı Somut Sınıfı
namespace Business.Concrete
{
    public class ProductManager : IProductService /*ProductManager Newlendiğinde constructor(18. Satırda) bloguna 
tanımlanan Tanımlanan referanı veriyoruz.*/

    {// İş kodları varsa;

        IProductDal _productDal;//Dependency Injection - Burada bunu yapmamızın sebebi DateAcess Layer katmanı ile haberleştirmek. 

        public ProductManager(IProductDal productDal) // Soyut nesne ile bağlantı kuruyoruz.
        {
            _productDal = productDal;
        }


        public IDataResult<List<Product>> GetAll()
        {
            //İş Kodları
            //Yetkisi var mı gibi kodlar yazılır.
            //if kodları burada yer alır.

            if (DateTime.Now.Hour == 19)
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
                //Maintenance Time > Bakım Zamanı
            {
                return new ErrorDataResult<List<ProductDetailDto>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        


        public IResult Add(Product product)
        {//business Codes - herşey geçerli ise buraya yazıyoruz. eğer böyleyse şöyle gibi durumları yazıyoruz.

            if (product.ProductName.Length < 2) //kötü kod yazım şekli
            {
                return new ErrorResult(Messages.ProductNameInValid);
            }


            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }
    }
}
