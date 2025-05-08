using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Interfaces
{
    public interface IPaymentModeService
    {
        Task<PaymentModeDTO[]> GetPaymentModes();
    }

    public interface IPaymentService
    {
        Task<PaymentTranDTO[]> GetAllStudentPayments(string rollNo);
    }
}
