namespace TLSRestApi.Attributes
{    
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public sealed class SkipTenantValidationAttribute : Attribute
    {
    }
    
}
