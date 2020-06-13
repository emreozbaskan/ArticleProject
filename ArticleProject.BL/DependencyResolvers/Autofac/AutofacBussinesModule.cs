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

    public class AutofacBussinesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EFUserRepository>().As<IUserRepository>();

            builder.RegisterType<AutManager>().As<IAutService>();
            builder.RegisterType<JWTHelper>().As<ITokenHelper>();
        }
    }
}
