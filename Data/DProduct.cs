using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;

namespace Data
{
    public class DProduct
    {
        private readonly string connectionString = "Data Source=LAB1504-26\\SQLEXPRESS;Initial Catalog=Lab5;User ID=hilari;Password=hilari123";

        public List<Product> GetByName()
        {
            List<Product> products = new List<Product>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("listarProductos", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product product = new Product
                            {
                                Name = reader["Name"].ToString(),
                                Price = (decimal)reader["Price"],
                                Stock = (int)reader["Stock"],
                                Active = (bool)reader["Active"]
                            };
                            products.Add(product);
                        }
                    }
                }
            }

            return products;
        }

        public void Insert(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@stock", product.Stock);
                    command.Parameters.AddWithValue("@active", product.Active);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UpdateProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@name", product.Name);
                    command.Parameters.AddWithValue("@price", product.Price);
                    command.Parameters.AddWithValue("@stock", product.Stock);
                    command.Parameters.AddWithValue("@active", product.Active);

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Delete(int product_id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DeleteProduct", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@product_id", product_id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}