using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Castle.DynamicProxy;

namespace ArticleProject.Core.Aspects.Autofac.Caching
{
    using Utilities.Interceptors;
    using CrossCuttingConcerns.Caching;
    using Utilities.IoC;

    public class CacheRemoveAspect : MethodInterception
    {
        private string _patern;
        private ICacheManager _cacheManager;
        public CacheRemoveAspect(string patern)
        {
            _patern = patern;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        protected override void onSuccess(IInvocation invocation)
        {
            _cacheManager.RemoveByPattern(_patern);
        }

    }
}
