﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Contracts.Unity.Request
{
    public class UnityPutRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
