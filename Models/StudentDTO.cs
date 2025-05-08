namespace CollegeManagementSystem.Models
{
    public class StudentDTO
    {
        public long Id { get; set; }

        public string? AdmissionNo { get; set; }

        public string? RollNo { get; set; }

        public string? FullName { get; set; }

        public string? FatherName { get; set; }

        public string? MotherName { get; set; }

        public string? Aadhaar { get; set; }

        public string? EmailId { get; set; }

        public string? MobileNo { get; set; }

        public string? AltMobileNo { get; set; }

        public string? StudCast { get; set; }

        public string? Address { get; set; }

        public DateOnly? Dob { get; set; }

        public DateOnly? Doj { get; set; }

        public bool? ScholarshipExists { get; set; }

        public string? SecondLang { get; set; }

        public double? TotalCourseFee { get; set; }

        public string? PrevCourse { get; set; }

        public string? PrevCollege { get; set; }

        public string? PrevUniversity { get; set; }

        public sbyte? Status { get; set; }
    }
}
