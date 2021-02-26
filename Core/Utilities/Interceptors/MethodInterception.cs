using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute //İş Kodlarım - invocation metod örtüm.
    {/* Biz Aspect nerede çalışsın istiyorsak onun ilgili metodunu orada eziyoruz. Aspect demek MethodInterception'ı aslında temel alan ve hangisi çalışsın istiyorsak
        onu içeren operasyondur.*/

        //Sırasıyla çalışacak.
        //Ezmeyi bekleyen metotlar yer alıyor.

        //invocation Kelime anlamı: Yardım için veya bir otorite olarak bir şeyi veya birini çağırma eylemi  - Burada kullanımı ise; Bussines Metodumuz.  

        protected virtual void OnBefore(IInvocation invocation) { }  
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {//Try Catch Hata  yakalama blogu.
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
