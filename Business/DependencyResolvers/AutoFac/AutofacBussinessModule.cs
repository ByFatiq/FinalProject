using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutofacBussinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {//Sürekli servis veya Dal operasyonları yenilemiyoruz. Burada tanımlayarak karşlığını vermemiz yeterli.
            
            
            base.Load(builder);
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces() // Autofac Interceptor- Çağırma görevi veriyor. Bu nedenle ilgili nesnenin aspecti varmı varsa 
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()// Varsa Onlar için olan AspectInterceptor'i çağır.
                }).SingleInstance();

        }
    }
}
