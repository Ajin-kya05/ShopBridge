using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDesc { get; set; }
        public int Price { get; set; }
        public string CreatedOn { get; set; }
        public string ModifiedOn { get; set; }
    }
}