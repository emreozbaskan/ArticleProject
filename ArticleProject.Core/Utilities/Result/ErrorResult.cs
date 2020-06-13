using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Core.Utilities.Result
{
    public class ErrorResult : Result
    {
        public ErrorResult() : base(false)
        {

        }

        public ErrorResult(string Message) : base(false, Message)
        {

        }
    }
}
