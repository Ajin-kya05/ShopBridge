using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopBridge.DataAccess.Repos.IRepos;
using ShopBridge.DataAccess.Queries;
using ShopBridge.ViewModels;

namespace ShopBridge.DataAccess.Repos
{
    public class ProductCRUDRepo : IProductCRUDRepo
    {
        DBOperation dbOp = new DBOperation();

        /// <summary>
        /// Get the list of all products or based on ID/Name
        /// </summary>
        /// <returns>Returns product list based on search parameters</returns>
        public List<ProductVM> GetProductList(string id,string name) {
            List<ProductVM> productList = dbOp.GetData<ProductVM>(new ProductQueries().GetProductListQuery(id,name));
            return productList;
        }

        /// <summary>
        /// Inserts a new product to DB
        /// </summary>
        /// <returns>No of rows affected</returns>
        public int InsertProduct(string pName, string pDesc, int price)
        {
            int result = dbOp.ExecuteQuery(new ProductQueries().InsertProductQuery(pName, pDesc, price));
            return result;
        }

        /// <summary>
        /// Update existing product based on ID
        /// </summary>
        /// <returns>No of rows affected</returns>
        public int UpdateProduct(string pName, string pDesc, int price,string id)
        {
            int result = dbOp.ExecuteQuery(new ProductQueries().UpdateProductQuery(pName, pDesc, price,id));
            return result;
        }

        /// <summary>
        /// Delete existing product based on ID
        /// </summary>
        /// <returns>No of rows affected</returns>
        public int DeleteProduct(string id)
        {
            int result = dbOp.ExecuteQuery(new ProductQueries().DeleteProductQuery(id));
            return result;
        }

    }
}