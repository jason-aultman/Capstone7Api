﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeCapstone7Api
{
    class Product
    {
        public int ProductId { get; set; }
        public string ProductName {get; set;}
        public int SupplierId { get; set; }
        public int CategoryId { get; set; }
        public string QuantityPerUnit { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public int UnitsOnOrder { get; set; }
        public int ReorderLevel { get; set; }
        public bool Discontinued { get; set; }
        public object Category { get; set; }
        public object Supplier { get; set; }
        
        public object[] OrderDetails { get; set; }
  
    }
}
