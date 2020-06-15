using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Core.CrossCuttingConcerns.Logging.Loggers
{
    public class DatabaseLogger: LoggerServiceBase
    {
        public DatabaseLogger():base("DatabaseLogger")
        {

        }
    }
}
