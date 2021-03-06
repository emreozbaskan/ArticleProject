﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace ArticleProject.Core.DependencyResolvers
{
    using CrossCuttingConcerns.Caching;
    using CrossCuttingConcerns.Caching.Microsoft;
    using Utilities.IoC;

    public class CoreModule : ICoreModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MemoryCacheManager>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
