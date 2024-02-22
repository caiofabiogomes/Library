using Library.Application.Commands.Loan.CreteLoan;
using Library.Application.Commands.Loan.FinishLoan;
using Library.Application.Queries.Loans.GetLoansByUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route($"api/loans")]
    [Authorize]
    public class LoansController : ControllerBase
    {
        private readonly IMediator _mediator;
        public LoansController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Post")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Post([FromBody] CreateLoanCommand command)
        {
            var response = await _mediator.Send(command);
            
            if (!response.IsFound)
                return NotFound(response.Message);

            if(!response.IsSuccess)
                return StatusCode(500, response.Message);

            return StatusCode(201,response.Message);
        }

        [HttpPut("FinishLoan")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> FinishLoan([FromBody] FinishLoanCommand command)
        {
            var response = await _mediator.Send(command);

            if(!response.IsFound)
                return NotFound();

            return Ok(response);
        }

        [HttpGet("GetMyLoans")]
        public async Task<IActionResult> GetMyLoans() 
        {
            var userIdClaim = User.Claims.FirstOrDefault(c => c.Type == "id");
            
            if (userIdClaim == null)
                return NotFound();

            var userId = Convert.ToInt32(userIdClaim.Value);

            var queryParams = new GetLoansByUserQuery(userId);

            var queryResult = await _mediator.Send(queryParams);

            return Ok(queryResult);
        }

    }
}
