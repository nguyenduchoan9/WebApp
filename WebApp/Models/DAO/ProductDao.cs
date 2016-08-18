using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApp.CommonClass;

namespace WebApp.Models.DAO
{
    public class ProductDao
    {
        SqlDatabaseSybEntities db = null;

        public ProductDao()
        {
            db = new SqlDatabaseSybEntities();
            db.Configuration.ProxyCreationEnabled = false;
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
            product.status = 0;
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

        public Product GetProductById(int id)
        {
            
            return db.Products.SingleOrDefault(x => x.id == id);
        }

        public bool UpdateProduct(int id, string productName, Decimal price, int discount, string description,
            string image)
        {
            var product = db.Products.SingleOrDefault(x => x.id == id);

            if (null != product)
            {
                product.name = productName;
                product.price = price;
                product.discount = discount;
                product.description = description;
                product.image = image;

                try
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


            return true;
        }

        public bool DeleteProductById(int id)
        {
            var product = db.Products.SingleOrDefault(x => x.id == id);

            if (null != product)
            {
                product.status = 1;

                try
                {
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            return true;
        }

        public void Change()
        {
            var list = db.Products.ToList();

            foreach (var product in list)
            {
                product.status = 0;

                db.Entry(product).State = EntityState.Modified;
            }
            db.SaveChanges();
        }


        public IEnumerable<Product> ListProductHomePage()
        {
            return db.Products.Where(x => x.status != 1).ToList();
        }

        public IEnumerable<CartItemDetail> ListCheckout(List<CartItem> listCartItem)
        {
            if (null == listCartItem)
            {
                return null;
            }

            var listCartItemDetail = new List<CartItemDetail>();

            var listProduct = db.Products.ToList();
            foreach (var cartItem in listCartItem)
            {
                var product = listProduct.SingleOrDefault(x => x.id == cartItem.IdProduct);

                var cartItemDetail = new CartItemDetail(product, cartItem.Quantity);

                listCartItemDetail.Add(cartItemDetail);
            }

            return listCartItemDetail;
        }

        public IEnumerable<Product> GetProductBySearchKey(string txtSearchKey)
        {
            if (!string.IsNullOrWhiteSpace(txtSearchKey))
            {
                var listProduct = from product in db.Products
                    where product.name.Contains(txtSearchKey)
                    select product;

                return listProduct;
            }

            return null;
        }
    }
}