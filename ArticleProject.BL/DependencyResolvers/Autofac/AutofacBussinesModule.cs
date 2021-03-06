﻿using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.BL.DependencyResolvers.Autofac
{
    using Concrete;
    using Abstract;
    using DAL.Concrete.EntityFramework;
    using DAL.Abstract;
    using Core.Utilities.Security.JWT;
    using global::Autofac.Extras.DynamicProxy;
    using Castle.DynamicProxy;
    using ArticleProject.Core.Utilities.Interceptors;

    public class AutofacBussinesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EFUserRepository>().As<IUserRepository>();
            builder.RegisterType<CategoryManager>().As<ICategoryService>();
            builder.RegisterType<EFCategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<CommentManager>().As<ICommentService>();
            builder.RegisterType<EFCommentRepository>().As<ICommentRepository>();
            builder.RegisterType<ArticleManager>().As<IArticleService>();
            builder.RegisterType<EFArticleRepository>().As<IArticleRepository>();

            builder.RegisterType<AutManager>().As<IAutService>();
            builder.RegisterType<JWTHelper>().As<ITokenHelper>();

            var assembly = System.Reflection.Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces().EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();

        }
    }
}
