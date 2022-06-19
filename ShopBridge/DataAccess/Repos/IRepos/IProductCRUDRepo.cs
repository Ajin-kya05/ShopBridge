using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBridge.ViewModels;
namespace ShopBridge.DataAccess.Repos.IRepos
{
    interface IProductCRUDRepo
    {
        List<ProductVM> GetProductList(string id, string name);
        int InsertProduct(string pName, string pDesc, int price);
        int UpdateProduct(string pName, string pDesc, int price, string id);
        int DeleteProduct(string id);
    }
}