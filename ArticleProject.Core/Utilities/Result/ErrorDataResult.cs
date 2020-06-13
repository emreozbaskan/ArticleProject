using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Core.Utilities.Result
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T Data) : base(Data, false)
        {

        }

        public ErrorDataResult(T Data, string Message) : base(Data, true, Message)
        {

        }

        public ErrorDataResult(string Message) : base(default, false, Message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
