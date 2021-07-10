using System;
using BillableTransactionDatabase.Exceptions;
using BillableTransactionDatabase.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


namespace BillableTransactionDatabase.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BillableTransactionDBContext _billableTransactionDBContext;
        private readonly IBillableTransactionRepository _billableTransaction;
        private readonly ILogger<UnitOfWork> _logger;
        private readonly ILogger<BillableTransactionRepository> _loggerBillableTransaction;

        public UnitOfWork(BillableTransactionDBContext billableTransactionDBContext, ILogger<UnitOfWork> logger, ILogger<BillableTransactionRepository> loggerBillableTransaction)
        {
            _logger = logger;
            _loggerBillableTransaction = loggerBillableTransaction;
            _billableTransactionDBContext = billableTransactionDBContext;
            _billableTransaction = new BillableTransactionRepository(_billableTransactionDBContext, _loggerBillableTransaction);
        }


        public void BeginTransaction()
        {
            _billableTransactionDBContext.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _billableTransactionDBContext.Database.CommitTransaction();
        }

        public void RollBackTransaction()
        {
            _billableTransactionDBContext.Database.RollbackTransaction();
        }

        public void Save()
        {
            try
            {
                BeginTransaction();
                _billableTransactionDBContext.SaveChanges();
                CommitTransaction();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                RollBackTransaction();
                string message = "Error to save changes on Database -> Save() " + Environment.NewLine + "Message: " + ex.Message + Environment.NewLine;
                _logger.LogError("{@message}" + Environment.NewLine + "Stack trace: {@Stacktrace}" + Environment.NewLine, message, ex.ToString());
                throw new CrudOperationException((int)ExceptionErrorCodes.InvalidData, "The set data are invalid, error in Database", ex.InnerException);
            }
            catch (DbUpdateException ex)
            {
                string message = "Error to save changes on Database -> Save() " + Environment.NewLine + "Message: " + ex.Message + Environment.NewLine;
                _logger.LogError("{@message}" + Environment.NewLine + "Stack trace: {@Stacktrace}" + Environment.NewLine, message, ex.ToString());
                throw new CrudOperationException((int)ExceptionErrorCodes.InvalidData, "The set data are invalid, error in Database", ex.InnerException);
            }
            catch (Exception ex)
            {
                RollBackTransaction();
                string message = "Error to save changes on Database -> Save() " + Environment.NewLine + "Message: " + ex.Message + Environment.NewLine;
                _logger.LogError("{@message}" + Environment.NewLine + "Stack trace: {@Stacktrace}" + Environment.NewLine, message, ex.ToString());
                throw new CrudOperationException((int)ExceptionErrorCodes.InternalServerError, "Can not save changes, error in Database", ex.InnerException);
            }
        }

        public IBillableTransactionRepository BillableTransaction
        {
            get
            {
                return _billableTransaction;
            }
        }
    }
}
