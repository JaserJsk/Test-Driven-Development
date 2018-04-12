using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_5._1
{

    public class Order 
    {
        public int OrderId;
        public List<OrderLine> orderLines { get; private set; }

        public Order()
        {
            orderLines = new List<OrderLine>();
        }

        public void AddOrderLine(OrderLine orderline)
        {
            if (!orderLines.Contains(orderline))
                orderLines.Add(orderline);
        }
    }

    public class OrderLine
    {

        public string Name;
        public decimal Price;
        public int Quantity;
    }
}
