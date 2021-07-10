using BillableTransactionDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendCodingExercise.Models
{
    public static class DAOFactory
    {
        public static Transaction GetDaoProfile(TransactionRequest transactionRequest)
        {
            return new Transaction()
            {
                Date = Convert.ToDateTime(transactionRequest.date),
                Amount = transactionRequest.amount,
                Description = transactionRequest.description,
                PaymentStatus = transactionRequest.paymentStatus,
            };
        }
    }
}
