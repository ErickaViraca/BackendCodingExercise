using System;
using System.Collections.Generic;
using System.Text;

namespace BillableTransactions.Models
{
    public class Transaction
    {
        public DateTime date { get; set; }
        public int amount { get; set; }
        public string description { get; set; }
        
        //un-billed, billed, paid
        public string paymentStatus { get; set; }
    }
}
