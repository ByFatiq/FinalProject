using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{//interceptor - Önleme 
    //validation doğrulama
    //aspect - Yön demek ; Başında veya sonunda veya hata verdiğinde çalışacak yapımız.
    public class ValidationAspect : MethodInterception //ValidationAspect Ana Aspectimiz.
    {
        private Type _validatorType; 
        public ValidationAspect(Type validatorType)//ValidatorType giriyor. Ctor blogu çalışıyor. Eğer doğrulama başarısız ise if bloğuna giriyor. 

        /*Eğer validator type'a rastgele bir product yazılır ise burada amaç onu engellemek. Bu sayede gelen product engellenir ve aşağıdaki hata bloguna girer.*/
        {

            //Defencive Codding - Savunma odaklı kodlama
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu Bir Doğrulama Sınıfı Değildir.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation) //Ezilecek metod bilgisi. Önce yapılmasını istediğimiz işi(Log bilgisi örneğin.) Doğrulama metodun başında yapıldığı için bunu burada yazıyoruz.
        //Başladığında yapılacak iş.
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);//Çalışma anında instance oluşturmak istersek activator.createinstance ile yapıyoruz.
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; //Product Validate'in basetype'ını bul 0. Argumanını product ise product ne geliyorsa. entities'e eşitle.
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity); //Validation Tool'u kullanarak doğrula.
            }
        }



    }
}
