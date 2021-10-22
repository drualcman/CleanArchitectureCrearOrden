using Sales.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Entities.POCOs
{
    public class SaleOrder
    {
        public int Id {  get; set; }
        public string CustomerId { get; set; }
        public string ShipAddress { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipPostalcode { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        public DiscountType DiscountType { get; set; } = DiscountType.Percentage;
        public double Discount { get; set; } = 10;
        public ShippingType ShipingType { get; set; } = ShippingType.Road;
        public List<SaleDetail> OrderDetails { get; set; } = new List<SaleDetail>();                 //aggregates (agregados)

        public void Add(SaleDetail orderDetail) => OrderDetails.Add(orderDetail);

        public void Add(int productId, decimal unitPrice, short quantity) =>
            OrderDetails.Add(new SaleDetail
            {
                ProductId = productId,
                UnitPrice = unitPrice,
                Quantity = quantity,
                Order = this
            });
    }
}
