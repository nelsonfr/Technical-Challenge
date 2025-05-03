using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transaction.Application.ViewModels;
using Serilog;
using Transaction.Application.DTOs;

namespace Transaction.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(CreateTransactionDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Post([FromBody] CreateTransactionDTO createTransactionDTO)
        {
            try
            {
                return Ok();
            }
            catch(Exception ex)
            {
                return HandleException(ex);
            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(TransactionDTO), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get(RetrieveTransactionDTO retrieveTransactionDTO)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        private ObjectResult HandleException(Exception ex)
        {
            Log.Error($"Error: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, new { exceptionMessage = ex.Message });
        }
    }
}
