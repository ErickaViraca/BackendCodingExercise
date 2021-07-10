using System;
using System.Collections.Generic;
namespace BackendCodingExercise.Models
{
    public class TransactionRequest
    {
        public DateTime date { get; set; }
        public int amount { get; set; }
        public string description { get; set; }

        //un-billed, billed, paid
        public string paymentStatus { get; set; }
    }
}
