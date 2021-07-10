using System;
using System.Collections.Generic;
using BillableTransactionDatabase.Models;
using BillableTransactionDatabase.Repository;
using Microsoft.Extensions.Logging;

namespace BackendCodingExercise.Services
{
    public class BillableTransactionService : IBillableTransactionService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger<BillableTransactionService> _loggerBillableTransaction;

        public BillableTransactionService(IUnitOfWork uow, ILogger<BillableTransactionService> logger)
        {
            _loggerBillableTransaction = logger;
            _uow = uow;
        }

        public Transaction RegisterTransaction(Transaction transaction)
        {
            try
            {
                _uow.BillableTransaction.Create(transaction);
                _uow.Save();
                return transaction;
            }
            catch (Exception ex)
            {
                throw new NotImplementedException();
            }
            
        }

        public Transaction UpdateBillingStatus(string id, string transactionStatus)
        {
            Transaction transaction = _uow.BillableTransaction.UpdateBillingStatus(id, transactionStatus);
            _uow.Save();
            return transaction;
        }

        public IEnumerable<Transaction> GenerateInvoicesByDateRange(DateTime startDate, DateTime endDate)
        {
            return _uow.BillableTransaction.GetBillableTransactionsByDateRange();
        }
    }
}
