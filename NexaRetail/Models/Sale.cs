using System;

namespace NexaRetail.Models
{
    public class Sale
    {
        public string InvoiceNo { get; set; }

        public DateTime SaleDate { get; set; }

        public string CustomerName { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; }

        public decimal Amount { get; set; }

        public string PaymentMode { get; set; }

        public string Status { get; set; }
    }
}
