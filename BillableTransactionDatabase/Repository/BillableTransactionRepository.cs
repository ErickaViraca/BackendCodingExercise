using System;
using System.Collections.Generic;
using System.Linq;
using BillableTransactionDatabase.Exceptions;
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
            try
            {
                _billableTransactionDBContext.AddRange(transaction);
            }
            catch (Exception ex)
            {
                string message = "Can not create the transaction in BillableTransactionRepository -> Create() " + Environment.NewLine + "Message: " + ex.Message + Environment.NewLine;
                _logger.LogError("{@message}" + Environment.NewLine + "Stack trace: {@Stacktrace}" + Environment.NewLine, message, ex.ToString());
                throw new CrudOperationException((int)ExceptionErrorCodes.ConflictData, "Already register", ex.InnerException);
            }
        }

        /// <summary>
        /// This method update the transaction status.
        /// </summary>
        /// <param name="id">Parameter by which the trassaction is searched</param>
        /// <param name="status">this parameter is the status transaction to modify</param>
        /// <exception cref="Exception">Can not update the status transaction by id.</exception>
        public Transaction UpdateBillingStatus(string id, string status)
        {
            try
            {
                Transaction transactionFounded = SearchProfileByUserId(id);
                transactionFounded.PaymentStatus = status;
                _billableTransactionDBContext.transaction.Update(transactionFounded);
                return transactionFounded;
            }
            catch (Exception ex)
            {
                string message = "Can not update the status transaction by id in BillableTransactionRepository -> UpdateBillingStatus() " + Environment.NewLine + "Message: " + ex.Message + Environment.NewLine;
                _logger.LogError("{@message}" + Environment.NewLine + "Stack trace: {@Stacktrace}" + Environment.NewLine, message, ex.ToString());
                throw new CrudOperationException((int)ExceptionErrorCodes.InvalidData, "Can not update the status transaction by id.", ex.InnerException);
            }
        }

        public IEnumerable<Transaction> GetBillableTransactionsByDateRange(DateTime startDate, DateTime endDate)
        {
            try
            {
                IEnumerable<Transaction> transactions = _billableTransactionDBContext.transaction.Where(m => m.Date <= endDate && m.Date > startDate).ToList();
                if (transactions.Count() > 0 || transactions.Any())
                {
                    return transactions;
                }
                else
                {
                    throw new CrudOperationException((int)ExceptionErrorCodes.NotFound, "Can not find any transactions in the database.");
                }
            }
            catch (Exception ex)
            {
                string message = "Can not find any transactions in BillableTransactionRepository -> GetBillableTransactionsByDateRange() " + Environment.NewLine + "Message: " + ex.Message + Environment.NewLine;
                _logger.LogError("{@message}" + Environment.NewLine + "Stack trace: {@Stacktrace}" + Environment.NewLine, message, ex.ToString());
                throw new CrudOperationException((int)ExceptionErrorCodes.NotFound, "Can not find any transactions.", ex.InnerException);
            }
        }
    }
}
