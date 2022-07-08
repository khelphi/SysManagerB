using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Helpers
{
    public class ResultData
    {
        public ResultData(object data, bool success)
        {
            this.Data = data;
            this.Success = success;
        }
        public bool Success { get; set; }
        public object Data { get; set; }
    }

}
