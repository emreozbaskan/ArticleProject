using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Core.Aspects.Autofac.Exception
{
    using Utilities.Interceptors;
    using CrossCuttingConcerns.Logging;
    using Utilities.Messages;
    using Castle.DynamicProxy;

    public class ExceptionLogAspect : MethodInterception
    {
        private LoggerServiceBase _loggerService;
        public ExceptionLogAspect(Type loggerService)
        {
            if (loggerService.BaseType != typeof(LoggerServiceBase))
                throw new System.Exception(AspectMessages.WrongLoggerType);

            _loggerService = (LoggerServiceBase)Activator.CreateInstance(loggerService);
        }
        protected override void onException(IInvocation invocation, System.Exception e)
        {
            LogDetailWithException logDetailWithException = GetLogDetail(invocation);
            logDetailWithException.ExceptionMessage = e.Message;
            _loggerService.Error(logDetailWithException);
        }

        private LogDetailWithException GetLogDetail(IInvocation invocation)
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
            var logDetailWithException = new LogDetailWithException()
            {
                MethodName = invocation.Method.Name,
                LogParameters = logParameters
            };
            return logDetailWithException;
        }
    }
}
