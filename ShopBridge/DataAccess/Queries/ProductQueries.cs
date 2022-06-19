using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopBridge.DataAccess.Queries
{
    public class ProductQueries
    {
        /// <summary>
        /// Get the list of all products or based on ID/Name
        /// </summary>
        /// <returns>Returns product list based on search parameters</returns>
        public string GetProductListQuery(string id, string name)
        {
            return $@"SELECT Id,ProductName,ProductDesc,Price,convert(varchar, CreatedOn, 101) AS CreatedOn,convert(varchar, ModifiedOn, 101) AS ModifiedOn FROM PRODUCT WHERE 1=1 " + (!string.IsNullOrEmpty(id) ? $" AND ID = '{id}' " : string.Empty) + (!string.IsNullOrEmpty(name) ? $" AND ProductName = '{name}' " : string.Empty);
        }

        /// <summary>
        /// Inserts a new product to DB
        /// </summary>
        public string InsertProductQuery(string pName, string pDesc, int price) => $@"INSERT INTO PRODUCT(ProductName, ProductDesc, Price) VALUES ('{pName}', '{pDesc}',{price} );";

        /// <summary>
        /// Updates the product based on product ID
        /// </summary>
        public string UpdateProductQuery(string pName, string pDesc, int price,string id) => $@"UPDATE PRODUCT SET ProductName='{pName}',ProductDesc='{pDesc}',Price='{price}',ModifiedOn=CURRENT_TIMESTAMP WHERE ID='{id}'";

        /// <summary>
        /// Delete the product based on product ID
        /// </summary>
        public string DeleteProductQuery(string id) => $@"DELETE FROM PRODUCT WHERE ID='{id}'";

    }
}