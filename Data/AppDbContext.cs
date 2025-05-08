using CollegeManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagementSystem.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext() { }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public virtual DbSet<CourseDetail> CourseDetails { get; set; }

    public virtual DbSet<FeeTransaction> FeeTransactions { get; set; }

    public virtual DbSet<IssuedStudentCertificate> IssuedStudentCertificates { get; set; }

    public virtual DbSet<PaymentMode> PaymentModes { get; set; }

    public virtual DbSet<StudentDetail> StudentDetails { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
    //        => optionsBuilder.UseMySql("server=localhost;database=college_db;user=root;password=admin", Microsoft.EntityFrameworkCore.ServerVersion.Parse("11.6.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CourseDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("course_details");

            entity.HasIndex(e => e.CourseCode, "course_code").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CourseCode)
                .HasMaxLength(15)
                .HasColumnName("course_code");
            entity.Property(e => e.CourseDuration)
                .HasColumnType("int(11)")
                .HasColumnName("course_duration");
            entity.Property(e => e.CourseFee).HasColumnName("course_fee");
            entity.Property(e => e.CourseName)
                .HasMaxLength(50)
                .HasColumnName("course_name");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("bigint(20)")
                .HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.MaxDuration)
                .HasColumnType("int(11)")
                .HasColumnName("max_duration");
            entity.Property(e => e.NumSemesters)
                .HasColumnType("int(11)")
                .HasColumnName("num_semesters");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("status");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("bigint(20)")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<FeeTransaction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("fee_transactions");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Amount).HasColumnName("amount");
            entity.Property(e => e.CourseCode)
                .HasMaxLength(15)
                .HasColumnName("course_code");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("bigint(20)")
                .HasColumnName("created_by");
            entity.Property(e => e.PaymentDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("payment_date");
            entity.Property(e => e.PaymentMode)
                .HasColumnType("int(11)")
                .HasColumnName("payment_mode");
            entity.Property(e => e.PaymentStatus)
                .HasColumnType("enum('Success','Pending','Failed')")
                .HasColumnName("payment_status");
            entity.Property(e => e.RollNo)
                .HasMaxLength(15)
                .HasColumnName("roll_no");
            entity.Property(e => e.TransactionId)
                .HasMaxLength(30)
                .HasColumnName("transaction_id");
        });

        modelBuilder.Entity<IssuedStudentCertificate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("issued_student_certificates");

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Certificate)
                .HasMaxLength(50)
                .HasColumnName("certificate");
            entity.Property(e => e.IssueDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("issue_date");
            entity.Property(e => e.IssuedBy)
                .HasColumnType("bigint(20)")
                .HasColumnName("issued_by");
            entity.Property(e => e.ReceivedBy)
                .HasMaxLength(50)
                .HasColumnName("received_by");
            entity.Property(e => e.RollNo)
                .HasMaxLength(15)
                .HasColumnName("roll_no");
        });

        modelBuilder.Entity<PaymentMode>(entity =>
        {
            entity.HasKey(e => e.ModeId).HasName("PRIMARY");

            entity.ToTable("payment_modes");

            entity.HasIndex(e => e.ModeName, "mode_name").IsUnique();

            entity.Property(e => e.ModeId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("mode_id");
            entity.Property(e => e.ModeName)
                .HasMaxLength(30)
                .HasColumnName("mode_name");
        });

        modelBuilder.Entity<StudentDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("student_details");

            entity.HasIndex(e => e.Aadhaar, "aadhaar").IsUnique();

            entity.HasIndex(e => e.AdmissionNo, "admission_no").IsUnique();

            entity.HasIndex(e => e.RollNo, "roll_no").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("bigint(20)")
                .HasColumnName("id");
            entity.Property(e => e.Aadhaar)
                .HasMaxLength(16)
                .HasColumnName("aadhaar");
            entity.Property(e => e.Address)
                .HasMaxLength(250)
                .HasColumnName("address");
            entity.Property(e => e.AdmissionNo)
                .HasMaxLength(25)
                .HasColumnName("admission_no");
            entity.Property(e => e.AltMobileNo)
                .HasMaxLength(12)
                .HasColumnName("alt_mobile_no");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("bigint(20)")
                .HasColumnName("created_by");
            entity.Property(e => e.Dob).HasColumnName("dob");
            entity.Property(e => e.Doj).HasColumnName("doj");
            entity.Property(e => e.EmailId)
                .HasMaxLength(100)
                .HasColumnName("email_id");
            entity.Property(e => e.FatherName)
                .HasMaxLength(60)
                .HasColumnName("father_name");
            entity.Property(e => e.FullName)
                .HasMaxLength(60)
                .HasColumnName("full_name");
            entity.Property(e => e.MobileNo)
                .HasMaxLength(12)
                .HasColumnName("mobile_no");
            entity.Property(e => e.MotherName)
                .HasMaxLength(60)
                .HasColumnName("mother_name");
            entity.Property(e => e.PrevCollege)
                .HasMaxLength(100)
                .HasColumnName("prev_college");
            entity.Property(e => e.PrevCourse)
                .HasMaxLength(20)
                .HasColumnName("prev_course");
            entity.Property(e => e.PrevUniversity)
                .HasMaxLength(100)
                .HasColumnName("prev_university");
            entity.Property(e => e.RollNo)
                .HasMaxLength(15)
                .HasColumnName("roll_no");
            entity.Property(e => e.ScholarshipExists)
                .HasDefaultValueSql("'0'")
                .HasColumnName("scholarship_exists");
            entity.Property(e => e.SecondLang)
                .HasMaxLength(30)
                .HasColumnName("second_lang");
            entity.Property(e => e.Status)
                .HasDefaultValueSql("'1'")
                .HasColumnType("tinyint(4)")
                .HasColumnName("status");
            entity.Property(e => e.StudCast)
                .HasMaxLength(10)
                .HasColumnName("stud_cast");
            entity.Property(e => e.TotalCourseFee).HasColumnName("total_course_fee");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("bigint(20)")
                .HasColumnName("updated_by");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Email, "email").IsUnique();

            entity.HasIndex(e => e.UserName, "user_name").IsUnique();

            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("user_id");
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("created_at");
            entity.Property(e => e.CreatedBy)
                .HasColumnType("bigint(20)")
                .HasColumnName("created_by");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .HasColumnName("email");
            entity.Property(e => e.LastLogin)
                .HasColumnType("timestamp")
                .HasColumnName("last_login");
            entity.Property(e => e.Mobile)
                .HasMaxLength(50)
                .HasColumnName("mobile");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.UpdatedAt)
                .ValueGeneratedOnAddOrUpdate()
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("timestamp")
                .HasColumnName("updated_at");
            entity.Property(e => e.UpdatedBy)
                .HasColumnType("bigint(20)")
                .HasColumnName("updated_by");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .HasColumnName("user_name");
            entity.Property(e => e.UserRole)
                .HasColumnType("tinyint(4)")
                .HasColumnName("user_role");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("user_role");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnType("tinyint(3) unsigned")
                .HasColumnName("id");
            entity.Property(e => e.UserRole1)
                .HasMaxLength(15)
                .HasColumnName("user_role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
