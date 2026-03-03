
using Domain.Entities;

namespace Application.DTOs
{
    public class EmployeeDTO
    {
        public int EmpId { get; set; }
        public int? EmpCatId { get; set; }
        public EmployeeCategory employeeCategory { get; set; }
        public string? EmployeeNumber { get; set; }
        public string? Names { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public DateTime? EntryDate { get; set; }
        public string? Company { get; set; }
        public string? Guild { get; set; }
        public decimal? Salary { get; set; }
        public DateTime? TerminationDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string? MaritalStatus { get; set; }
        public string? Gender { get; set; }
        public string? PhotoUrl { get; set; }
        public string? RFC { get; set; }
        public string? CURP { get; set; }
        public string? NSS { get; set; }
        public string? INE { get; set; }
        public string? DriveLicense { get; set; }
        public DateTime? DriveLicenseDateExp { get; set; }
        public bool? CertificatedForeignDriver { get; set; }
        public string? BloodType { get; set; }
        public string? EducationLevel { get; set; }
        public string? Comments { get; set; }
    }
}
