using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;

namespace ArticleProject.Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void onAfter(IInvocation invocation) { }
        protected virtual void onException(IInvocation invocation, System.Exception e) { }
        protected virtual void onSuccess(IInvocation invocation) { }


        public override void Intercept(IInvocation invocation)
        {
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                onException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                    onSuccess(invocation);
            }
            onAfter(invocation);
        }
    }
}
