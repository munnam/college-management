using AutoMapper;
using CollegeManagementSystem.Entities;
using CollegeManagementSystem.Models;

namespace CollegeManagementSystem.Services
{
    public class MappingProfile : Profile
    {
        // Note: All the Entites to DTO mapping need to be done fist to use AutoMapper.
        public MappingProfile()
        {
            CreateMap<CourseDetail, CourseDetailDTO>();
            CreateMap<CourseDetailDTO, CourseDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());  // Ignore Id for DTO to Entity (especially during creation)

            CreateMap<FeeTransaction, PaymentTranDTO>();
            CreateMap<PaymentTranDTO, FeeTransaction>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());  // Ignore Id for DTO to Entity (especially during creation)

            CreateMap<StudentDetail, StudentDTO>();
            CreateMap<StudentDTO, StudentDetail>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());  // Ignore Id for DTO to Entity (especially during creation)

            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.UserId, opt => opt.Ignore());  // Ignore Id for DTO to Entity (especially during creation)

            CreateMap<PaymentMode, PaymentModeDTO>();
            CreateMap<IssuedStudentCertificate, StudentCertificate>();

        }
    }
}
