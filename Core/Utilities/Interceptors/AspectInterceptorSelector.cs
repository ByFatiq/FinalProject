using System;
using System.Linq;
using System.Reflection;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector // Bu class; ilgili attributleri oku metotları oku ve onları bir listeye koy. Öncelik listesine göre sırala.  
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute> 
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);






           // classAttributes.Add(new ExceptionLogAspect(typeof(FileLogger))); // Otomatik olarak sistemdeki bütün metotları loga dahil et. Loglama alt yapısını yazdıktan sonra kullanılır.

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}