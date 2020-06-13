using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Core.Utilities.Result
{
    public class SuccessResult : Result
    {
        public SuccessResult() : base(true)
        {
        }

        public SuccessResult(string Message) : base(true, Message)
        {

        }
    }
}
