using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.POCOs
{
    public class SaleDetail
    {
        public int OrderId {  get; set; }
        public int ProdcutId { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public SaleOrder Order { get; set; }
    }
}
