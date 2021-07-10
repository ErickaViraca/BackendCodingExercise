using System;

namespace BillableTransactionDatabase.Models
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }

        //un-billed, billed, paid
        public string PaymentStatus { get; set; }
    }
}
