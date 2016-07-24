using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp.Models.DAO
{
    public class ProductDao
    {
        SqlDatabaseSybEntities db = null;

        public ProductDao()
        {
            db = new SqlDatabaseSybEntities();
        }

        public IEnumerable<Product> GetList()
        {
            return db.Products.ToList();
        }

        /*
         * param: string prodcutName
         * output:
         *      -1 : prodcutName exist
         *       0 : prodcutName not exist
             */

        public int CheckProductNameExist(string productName)
        {
            var productNameExist = db.Products.SingleOrDefault(x => x.name.Equals(productName));
            if (null != productNameExist)
            {
                return -1;
            }
            return 0;
        }
        /*
         * param: Product product
         * output:
         *      -1 : insert into DB error
         *       0 : insert successfully
           */
        public int AddNewProduct(Product product)
        {
            int maxId = db.Products.Max(x => x.id);
            int id = maxId + 1;
            product.id = id;
            try
            {
                db.Products.Add(product);
                db.SaveChanges();
            }
            catch (Exception)
            {
                return -1;
            }
            return 0;
        }
    }
}