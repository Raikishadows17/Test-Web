using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class Tenant
    {    
        public int TenantId { get; set; }
        public string TenantName { get; set; } = string.Empty;
        public string TenantKeyName { get; set; } = string.Empty;
        public string? DatabaseConnectionString { get; set; }
        public bool Active { get; set; }
    }
}
