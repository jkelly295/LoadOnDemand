using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace LoadOnDemandSQL2016.Models
{
    public class Items
    {
       public  IList<Item> ItemList = new List<Item>();

        public Items(int PageNumber)
        {
            /* Grabs the data from the database for just the page / results we request.
             * See SQL statement for how db query is accomplishing this.
             */

            var cString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\VSProjects4SourceTree\LoadOnDemandSQL2016\App_Data\Database1.mdf;Integrated Security=True";
                string sql = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("/Models/SQL/GetItemData.sql"));
                using (var connection = new SqlConnection(cString))
                {
                var command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@Page", PageNumber);
                connection.Open();
                using (var reader = command.ExecuteReader())
                {
                    int i = 0;
                    while (reader.Read())
                    {
                        string ImageName;
                        if (i % 2 == 0){
                            ImageName = "3216.jpg";
                        }
                        else
                        {
                            ImageName = "3217.jpg";
                        }
                        ItemList.Add(new Item(reader["SKU"].ToString(), reader["Name"].ToString(), ImageName));
                        i += 1;
                    }
                }
                }
      

        }

        public class Item
        {
            public Item(string inSKU, string inName, string inImage)
            {
                SKU = inSKU;
                Name = inName;
                Image = inImage;
                
            }

            public string SKU { get; set; }
            public string Name { get; set; }
            public string Image { get; set; }
        }

    }
}