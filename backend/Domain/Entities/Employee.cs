using Domain.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    [Table("Employee")]
    public class Employee : IActivable,IEntity
    {
        [Key]
        [Column("Emp_Id")]
        public int Id { get; set; }

        [Column("Emp_Cat_Id")]
        public int EmpCatId { get; set; }

        [MaxLength(50)]
        [Column("Employee_Number")]
        public string? EmployeeNumber { get; set; }

        [MaxLength(200)]
        [Column("Names")]
        public string? Names { get; set; }

        [MaxLength(200)]
        [Column("Middle_Name")]
        public string? MiddleName { get; set; }

        [MaxLength(200)]
        [Column("Last_Name")]
        public string? LastName { get; set; }

        [MaxLength(500)]
        [Column("Full_Name")]
        public string? FullName { get; set; }

        [MaxLength(200)]
        [Column("Email")]
        public string? Email { get; set; }

        [Column("Entry_Date")]
        public DateTime? EntryDate { get; set; }

        [MaxLength(200)]
        [Column("Company")]
        public string? Company { get; set; }

        [MaxLength(200)]
        [Column("Guild")]
        public string? Guild { get; set; }

        [Column("Salary", TypeName = "decimal(18,2)")]
        public decimal? Salary { get; set; }

        [Column("Termination_Date")]
        public DateTime? TerminationDate { get; set; }

        [Column("Birth_Date")]
        public DateTime? BirthDate { get; set; }

        [MaxLength(50)]
        [Column("Marital_Status")]
        public string? MaritalStatus { get; set; }

        [MaxLength(20)]
        [Column("Gender")]
        public string? Gender { get; set; }

        [MaxLength(500)]
        [Column("Photo_Url")]
        public string? PhotoUrl { get; set; }

        [MaxLength(13)]
        [Column("RFC")]
        public string? RFC { get; set; }

        [MaxLength(18)]
        [Column("CURP")]
        public string? CURP { get; set; }

        [MaxLength(20)]
        [Column("NSS")]
        public string? NSS { get; set; }

        [MaxLength(50)]
        [Column("INE")]
        public string? INE { get; set; }

        [MaxLength(100)]
        [Column("Drive_License")]
        public string? DriveLicense { get; set; }

        [Column("Drive_License_DateExp")]
        public DateTime? DriveLicenseDateExp { get; set; }

        [Column("Certificated_ForeignDriver")]
        public bool? CertificatedForeignDriver { get; set; } = false;

        [MaxLength(10)]
        [Column("BloodType")]
        public string? BloodType { get; set; }

        [MaxLength(100)]
        [Column("Education_level")]
        public string? EducationLevel { get; set; }

        [Column("Active")]
        public bool Active { get; set; } = true;

        [MaxLength(500)]
        [Column("Comments")]
        public string? Comments { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(EmpCatId))]
        public virtual EmployeeCategory EmployeeCategory { get; set; }

        public virtual ICollection<User> Users { get; set; } = new List<User>();
        public virtual ICollection<AssignedOperator> AssignedOperators { get; set; } = new List<AssignedOperator>();
        public virtual ICollection<EmployeeDisabled> EmployeeDisableds { get; set; } = new List<EmployeeDisabled>();
        public virtual ICollection<ForbiddenEmployee> ForbiddenEmployees { get; set; } = new List<ForbiddenEmployee>();
        public virtual ICollection<PersonalAddress> PersonalAddresses { get; set; } = new List<PersonalAddress>();
        public virtual ICollection<PersonalContact> PersonalContacts { get; set; } = new List<PersonalContact>();
    }
}
