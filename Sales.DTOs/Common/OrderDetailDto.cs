using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DTOs.Common
{
    public class OrderDetailDto
    {
        public int ProdcutId { get; set; }
        public string ProdutName { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
    }
}
