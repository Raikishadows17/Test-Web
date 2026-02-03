using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class Tenant
    {
        public string TenantId { get; set; } = string.Empty;
        public string TenantName { get; set; } = string.Empty;
        public string DatabaseConnectionString { get; set; } = string.Empty;
        public string StorageConnectionString { get; set; } = string.Empty;
        public string StorageContainerName { get; set; } = string.Empty;
        public bool Active { get; set; } = true;
        public DateTime FechaCreacion { get; set; } = DateTime.UtcNow;
    }
}
