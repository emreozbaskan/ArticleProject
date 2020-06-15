using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Core.CrossCuttingConcerns.Logging.Loggers
{
    public class FileLogger : LoggerServiceBase
    {
        public FileLogger() : base("JsonFileLogger")
        {
                
        }
    }
}
