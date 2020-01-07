using System;
using System.Collections.Generic;
using System.Text;

namespace Inventorydata.data
{
    public class StockRequest
    {
        public int ID { get; set; }

        public int ProductID { get; set; }

        public int StaffID { get; set; }

        public int RequestedQuantity { get; set; }

        public Boolean ApprovalStatus { get; set; }

        public Staff Staff { get; set; }

        public Product Product { get; set; }

    }
}
