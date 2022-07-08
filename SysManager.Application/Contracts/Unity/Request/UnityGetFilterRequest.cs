using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Contracts.Unity.Request
{
    public class UnityGetFilterRequest
    {
        public string Name { get; set; }
        public string Active { get; set; }
        public int page { get; set; }
        public int pageSize { get; set; }
    }
}
