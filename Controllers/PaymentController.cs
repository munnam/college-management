using CollegeManagementSystem.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollegeManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController(IPaymentModeService paymentModeService, IPaymentService paymentService) : ControllerBase
    {
        private readonly IPaymentModeService _paymentModeService = paymentModeService;
        private readonly IPaymentService _paymentService = paymentService;

        [HttpGet("modes")]
        public async Task<IActionResult> GetPaymentModes()
        {
            var modes = await _paymentModeService.GetPaymentModes();

            return Ok(modes);
        }

        [HttpGet("student/{rollNo}")]
        public async Task<IActionResult> GetPaymentByStudent(string rollNo)
        {
            var payments = await _paymentService.GetAllStudentPayments(rollNo);

            return Ok(payments);
        }

    }
}
