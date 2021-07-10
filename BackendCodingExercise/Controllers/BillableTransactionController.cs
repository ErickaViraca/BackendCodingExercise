using System;
using System.Threading.Tasks;
using BackendCodingExercise.Models;
using BackendCodingExercise.Services;
using BillableTransactionDatabase.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendCodingExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillableTransactionController : ControllerBase
    {
        private readonly IBillableTransactionService _billableTransactionService;

        public BillableTransactionController(IBillableTransactionService billableTransactionService)
        {
            _billableTransactionService = billableTransactionService;
        }

        /// <summary>
        /// Save new transaction
        /// </summary>
        /// <param name="user">Profile user information to save</param>
        /// <returns>returns a profile information that was stored</returns>
        [HttpPost]
        public async Task<IActionResult> CreateTransaction([FromBody] TransactionRequest transactionRequest)
        {
            Transaction transaction = DAOFactory.GetDaoProfile(transactionRequest);
            return Ok(_billableTransactionService.RegisterTransaction(transaction));
        }

        /// <summary>
        /// Update status of transaction.
        /// </summary>
        /// <param name="userId">transaction id by wich the transaction will be searched</param>
        /// <param name="status">transaction status information to update</param>
        /// <returns>returns a transaction information that was updated</returns>
        [HttpPut]
        [Route("{id}/status")]
        public async Task<IActionResult> UpdateTransactionStatus(string transactionId, [FromQuery] string transactionStatus)
        {
            Transaction transaction = _billableTransactionService.UpdateBillingStatus(transactionId, transactionStatus);
            return Ok(transaction);
        }

        /// <summary>
        /// return all transactions at database by date range
        /// </summary>
        /// /// <param name="startDate">start date by wich the transactions will be searched</param>
        /// /// <param name="endDate">end date by wich the transactions will be searched</param>
        /// <returns>Returns all transactions information found</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllTransactionsByDateRange([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {
            return Ok(_billableTransactionService.GenerateInvoicesByDateRange(startDate, endDate));
        }
    }
}
