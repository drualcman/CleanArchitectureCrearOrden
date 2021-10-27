using Sales.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.ViewModels
{
    public class OrdersViewModel
    {
        public IEnumerable<OrderDto> Orders { get; }
        public OrdersViewModel(IEnumerable<OrderDto> orders) => Orders = orders;
    }
}
