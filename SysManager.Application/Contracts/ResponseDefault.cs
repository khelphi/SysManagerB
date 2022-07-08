using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Contracts
{
    public class ResponseDefault
    {
        public ResponseDefault(string id, string message, bool hasError)
        {
            this.Id = id;
            this.Message = message;
            this.HasError = hasError;
        }
        public string Id { get;set;}
        public string Message { get; set; }
        public bool HasError { get; set; }
    }
}
