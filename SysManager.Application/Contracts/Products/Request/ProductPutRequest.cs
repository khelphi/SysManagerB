﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SysManager.Application.Contracts.Products.Request
{
    public class ProductPutRequest
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string ProductType { get; set; }
        public string ProductCategory { get; set; }
        public string ProductUnity { get; set; }
        public decimal CostPrice { get; set; }
        public decimal Percentage { get; set; }
        public decimal Price { get; set; }
        public bool Active { get; set; }
    }
}
