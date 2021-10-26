using Microsoft.AspNetCore.Components;
using Sales.BlazorClient.Exceptions;
using Sales.BlazorClient.Services;
using Sales.DTOs.CreateOrder;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sales.BlazorClient.Pages
{
    public partial class Index
    {
        [Inject]
        public SalesApiClient Service { get; set; }

        CreateOrderDto Order = new CreateOrderDto
        {
            OrderDetails = new List<CreateOrderDetailDto>()
        };

        string Message;
        HttpCustomException Exception;

        void AddProduct()
        {
            Order.OrderDetails.Add(new CreateOrderDetailDto());
        }

        async Task Send()
        {
            try
            {
                int orderId = await Service.CreateOrder(Order);
            }
            catch (HttpCustomException ex)
            {
                Message = "";
                Exception = ex;
            }
            catch(Exception ex)
            {
                Message = ex.Message;
                Exception = null;
            }
        }
    }
}
