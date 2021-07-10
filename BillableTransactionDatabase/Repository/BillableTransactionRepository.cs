using System;
using System.Collections.Generic;
using BillableTransactionDatabase.Models;
using Microsoft.Extensions.Logging;

namespace BillableTransactionDatabase.Repository
{
    public class BillableTransactionRepository : IBillableTransactionRepository
    {
        private readonly BillableTransactionDBContext _billableTransactionDBContext;
        private readonly ILogger<BillableTransactionRepository> _logger;

        public BillableTransactionRepository(BillableTransactionDBContext billableTransactionDBContext, ILogger<BillableTransactionRepository> logger)
        {
            _logger = logger;
            _billableTransactionDBContext = billableTransactionDBContext;
        }

        /// <summary>
        /// This method register a new billable transaction
        /// </summary>
        /// <param name="transaction">this parameter is the model of the Transaction</param>
        /// <exception cref="Exception">The transaction is already register</exception>
        public void Create(Transaction transaction)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetBillableTransactionsByDateRange()
        {
            throw new NotImplementedException();
        }

        public Transaction UpdateBillingStatus(string id, string status)
        {
            throw new NotImplementedException();
        }
    }
}
