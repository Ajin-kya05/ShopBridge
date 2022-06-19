using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using ShopBridge.DataAccess;
using ShopBridge.DataAccess.Repos;
using ShopBridge.DataAccess.Repos.IRepos;

namespace ShopBridge.Controllers
{
    public class ProductController : ApiController
    {
        private IProductCRUDRepo _product;
        public ProductController() {
            _product = new ProductCRUDRepo();
        }

        [HttpGet]
        public IHttpActionResult GetProductList(string id,string name) {
            return (Ok(new Response
            {
                Status = HttpStatusCode.OK,
                Message = "Success",
                Data = _product.GetProductList(id,name)
            }));
        }


        [HttpGet]
        public IHttpActionResult InsertProduct(string pName, string pDesc, int price)
        {
            return (Ok(new Response
            {
                Status = HttpStatusCode.OK,
                Message = "Success",
                Data = _product.InsertProduct(pName, pDesc,price)
            }));
        }


        [HttpGet]
        public IHttpActionResult UpdateProduct(string pName, string pDesc, int price,string id)
        {
            return (Ok(new Response
            {
                Status = HttpStatusCode.OK,
                Message = "Success",
                Data = _product.UpdateProduct(pName, pDesc,price,id)
            }));
        }


        [HttpGet]
        public IHttpActionResult DeleteProduct(string id)
        {
            return (Ok(new Response
            {
                Status = HttpStatusCode.OK,
                Message = "Success",
                Data = _product.DeleteProduct(id)
            }));
        }

    }
}