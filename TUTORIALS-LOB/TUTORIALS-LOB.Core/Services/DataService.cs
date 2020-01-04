using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

using TUTORIALS_LOB.Core.Models;

namespace TUTORIALS_LOB.Core.Services
{
  
    public static class DataService
    {
        public static async Task<IEnumerable<Order>> GetOrdersAsync()
        {
            using (SqlConnection conn = new SqlConnection(
            "Database=WideWorldImporters;Server=.;User ID=sa;Password=pass"))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand("select o.OrderId, " +
                    "c.CustomerName, o.OrderDate, o.PickingCompletedWhen, " +
                    "sum(l.Quantity * l.UnitPrice) as OrderTotal " +
                    "from Sales.Orders o " +
                    "inner join Sales.Customers c on c.CustomerID = o.CustomerID " +
                    "inner join Sales.OrderLines l on o.OrderID = l.OrderID " +
                    "group by o.OrderId, c.CustomerName, o.OrderDate,  " +                   
                   " o.PickingCompletedWhen " +                   
                    "order by o.OrderDate desc", conn);
                    var results = new List<Order>();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var order = new Order
                            {
                                Company = reader.GetString(1),
                                OrderId = reader.GetInt32(0),
                                OrderDate = reader.GetDateTime(2),
                                OrderTotal = reader.GetDecimal(4),
                                DatePicked = !reader.IsDBNull(3) ? reader.GetDateTime(3) :
                            (DateTime?)null
                            };
                            results.Add(order);
                        }
                        return results;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        public static async Task<IEnumerable<OrderItem>> GetOrderItemsAsync(
         int orderId)
        {
            using (SqlConnection conn = new SqlConnection(
            "Database=WideWorldImporters;Server=.;User ID=sa;Password=pass"))
            {
                try
                {
                    await conn.OpenAsync();
                    SqlCommand cmd = new SqlCommand($"select Description,Quantity,UnitPrice from Sales.OrderLines where OrderID = {orderId}", conn);
                    var results = new List<OrderItem>();
                    using (SqlDataReader reader = await cmd.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            var orderItem = new OrderItem
                            {
                                Description = reader.GetString(0),
                                Quantity = reader.GetInt32(1),
                                UnitPrice = reader.GetDecimal(2),
                            };
                            results.Add(orderItem);
                        }
                        return results;
                    }
                }
                catch
                {
                    return null;
                }
            }
        }
        public static async Task<IEnumerable<Order>> GetMasterDetailDataAsync()
        {
            await Task.CompletedTask;
            return await GetOrdersAsync();
        }
    }
}
