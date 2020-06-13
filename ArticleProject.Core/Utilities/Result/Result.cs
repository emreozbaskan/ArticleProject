using System;
using System.Collections.Generic;
using System.Text;

namespace ArticleProject.Core.Utilities.Result
{
    public class Result : IResult
    {
        public Result(bool Success, string Message) : this(Success)
        {
            this.Message = Message;
        }

        public Result(bool Success)
        {
            this.Success = Success;
        }

        public bool Success { get; private set; }

        public string Message { get; private set; }
    }
}
