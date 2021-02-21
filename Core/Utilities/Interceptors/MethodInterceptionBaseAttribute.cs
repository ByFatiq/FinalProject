﻿using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;


namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {
        public int Priority { get; set; } // öncelik sırasını belirtir. ilk önce loglama sonra yetkilendirme gibi hangisi ilk önce çalışsın.?

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }
}