namespace TLSRestApi.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class SkipApiKeyValidationAttribute : Attribute
    {
    }
}
