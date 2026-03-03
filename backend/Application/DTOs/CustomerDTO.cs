
using Domain.Common;

namespace Application.DTOs
{
    public class CustomerDTO
    {
        
        public int CustomerId { get; set; }
        public int? TripTypeId { get; set; }

        public int? PaymentTermId { get; set; }

        public int? ActualExecutiveId { get; set; }

        public string Nickname { get; set; } = string.Empty;
        public string? Names { get; set; }

        public string? MiddleName { get; set; }

        public string? LastName { get; set; }

        public string? FullName { get; set; }

        public string? CompanyName { get; set; }

        public string? RfcCompany { get; set; }

        public string? CustPosition { get; set; }

        public string? UrlWebPage { get; set; }

        public string? UrlInvoicing { get; set; }

        public DateTime? CreationDate { get; set; }

        public DateTime? ModifyDate { get; set; }

        public bool? ContractActual { get; set; }

        public bool? CertificatedCustomer { get; set; }

        public bool? BaseContract { get; set; }

        public bool? ContractPersonalized { get; set; }

        public string? Comments { get; set; }
    }
}
