using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;


namespace ArticleProject.Core.Aspects.Autofac.Logging
{
    using Utilities.Messages;
    using CrossCuttingConcerns.Logging;
    using Utilities.Interceptors;

    public class LogAspect : MethodInterception
    {
        LoggerServiceBase _loggerServiceBase;
        public LogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new System.Exception(AspectMessages.WrongLoggerType);
            _loggerServiceBase = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }

        protected override void OnBefore(IInvocation invocation)
        {
            _loggerServiceBase.Info(GetLogDetail(invocation));
        }

        protected override void onException(IInvocation invocation, System.Exception e)
        {
            _loggerServiceBase.Error(GetLogDetail(invocation));
        }

        private LogDetail GetLogDetail(IInvocation invocation)
        {
            var logParameters = new List<LogParameter>();
            for (int i = 0; i < invocation.Arguments.Length; i++)
            {
                logParameters.Add(new LogParameter()
                {
                    Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                    Value = invocation.Arguments[i],
                    Type = invocation.Arguments[i].GetType().Name
                });
            }
            var logDetail = new LogDetail()
            {
                LogParameters = logParameters,
                MethodName = invocation.Method.Name
            };
            return logDetail;
        }

    }
}
