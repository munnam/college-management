using System;
using System.Collections.Generic;

namespace CollegeManagementSystem.Entities;

public partial class StudentDetail
{
    public long Id { get; set; }

    public string AdmissionNo { get; set; } = null!;

    public string RollNo { get; set; } = null!;

    public string FullName { get; set; } = null!;

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

    public DateTime? CreatedAt { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime? UpdatedAt { get; set; }

    public long? UpdatedBy { get; set; }
}
