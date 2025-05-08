using AutoMapper;
using CollegeManagementSystem.Data;
using CollegeManagementSystem.Interfaces;
using CollegeManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementSystem.Services
{
    public class PaymentService(AppDbContext dbContext, IMapper mapper) : IPaymentModeService, IPaymentService
    {
        async Task<PaymentTranDTO[]> IPaymentService.GetAllStudentPayments(string rollNo)
        {
            var payments = await dbContext.FeeTransactions
                                    .Where(t => t.RollNo == rollNo)
                                    .ToArrayAsync();

            return mapper.Map<PaymentTranDTO[]>(payments);
        }

        async Task<PaymentModeDTO[]> IPaymentModeService.GetPaymentModes()
        {
            var modes = await dbContext.PaymentModes
                                 // TODO: When DB update uncomment the following.
                                 //.Where(pm => pm.status > 0)
                                 // .Select(p => new PaymentModeDTO { ModeId = p.ModeId, ModeName = p.ModeName })
                                 .Select(p => p)
                                 .ToArrayAsync();
            return mapper.Map<PaymentModeDTO[]>(modes);
        }
    }
}
