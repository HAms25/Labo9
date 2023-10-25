using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Data;
using System.Xml.Linq;

namespace Business
{
    public class BProduct
    {
        public List<Product> GetByName(string name)
        {
            List<Product> result = new List<Product>();

            DProduct data = new DProduct();

            var products = data.GetByName();


            result=products.Where(x=>x.Name.Contains(name)).ToList();

            //foreach (var item in products) 
            //{
            //    if (item.Name.ToLower() == name.ToLower())
            //    {
            //        result.Add(item);
            //    }
            //}

            return result;
        }

        public void Insert(Product product)
        {
            DProduct data = new DProduct();
            data.Insert(product);
        }

        public void Update(Product product)
        {
            DProduct data = new DProduct();
            data.Update(product);
        }

        public void Delete(int product_id)
        {
            DProduct data = new DProduct();
            data.Delete(product_id);
        }
    }
}