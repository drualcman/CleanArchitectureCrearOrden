using LinqExpressionToSqlTranslator;
using Sales.DTOs.Common;
using Sales.Entities.Specifications;
using Sales.UseCases.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;

namespace Sales.Repository.ADONET
{
    public class OrderReadableRepository : IOrderReadableRepository, IDisposable
    {
        readonly IDbConnection Connection;

        public OrderReadableRepository(IDbConnection connection) => Connection = connection;


        public IEnumerable<OrderDto> GetOrderWithDetailsBySpecification(Specification<OrderDto> specification)
        {
            List<OrderDto> orders = new List<OrderDto>();

            string fields = "O.Id, O.CustomerId, O.OrderDate, O.ShipAddress, O.ShipCity, " +
                            "O.ShipCountry, O.ShipPostalCode, " +
                            "D.ProductId, D.UnitPrice, D.Quantity, " +
                            "C.[Name] as CustomerName, P.[Name] as ProductName";
            string tables = "Orders as O inner join OrderDetails as D on O.Id = D.OrderId " +
                            "inner join Customers as C on O.CustomerId = C.Id " +
                            "inner join Products as P on D.ProductId = P.Id";
            // mirar otra clase
            Translator translator = new Translator();
            string where = translator.Translate(specification, specification.ConditionExpresion);

            string sql = $"SELECT {fields} FROM {tables} WHERE {where} ORDER BY O.Id";

            IDbCommand command = Connection.CreateCommand();
            command.CommandText = sql;
            Connection.Open();
            IDataReader reader = command.ExecuteReader();
            int currentId;
            OrderDto order;
            bool hasOrders;
            
            if (reader.Read())
            {
                do
                {
                    currentId = Convert.ToInt32(reader["Id"]);
                    order = new OrderDto
                    {
                        OrderId = currentId,
                        CustomerId = reader["CustomerId"].ToString(),
                        CustomerName = reader["CustomerName"].ToString(),
                        OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                        ShipAddress = reader["ShipAddress"].ToString(),
                        ShipCity = reader["ShipCity"].ToString(),
                        ShipCountry = reader["ShipCountry"].ToString(),
                        ShipPostalCode = reader["ShipPostalCode"].ToString(),
                        OrdersDetail = new List<OrderDetailDto>()
                    };
                    do
                    {
                        order.OrdersDetail.Add(
                            new OrderDetailDto
                            {
                                ProdcutId = Convert.ToInt32(reader["ProductId"]),
                                ProdutName = reader["ProductName"].ToString(),
                                UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
                                Quantity = Convert.ToInt16(reader["Quantity"])
                            });
                    } while ((hasOrders = reader.Read()) && Convert.ToInt32(reader["ID"]) == currentId);
                    
                    orders.Add(order);

                } while (hasOrders);
            }
            reader.Dispose();
            command.Dispose();
            Connection.Close();

            return orders;
        }


        public void Dispose()
        {
            Connection?.Dispose();
        }
    }
}
