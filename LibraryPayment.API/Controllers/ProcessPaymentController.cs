using LibraryPayment.Application.InputModels;
using LibraryPayment.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LibraryPayment.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProcessPaymentController : ControllerBase
    {
        private readonly IProcessPaymentService _processPaymentService;
        public ProcessPaymentController(IProcessPaymentService processPaymentService)
        {
            _processPaymentService = processPaymentService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post([FromBody] ProcessPaymentInputModel input)
        {
            var result = await _processPaymentService.ProcessPaymentCreditCard(input);

            return Ok(result);
        }
    }
}