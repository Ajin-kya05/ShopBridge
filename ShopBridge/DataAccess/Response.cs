using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

namespace ShopBridge.DataAccess
{
    public class Response
    {
        public string Message { get; set; }
        public dynamic Data { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}