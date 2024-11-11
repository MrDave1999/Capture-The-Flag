#if NET6_0
namespace System.Runtime.CompilerServices;

[AttributeUsage(
    AttributeTargets.Class |
    AttributeTargets.Field |
    AttributeTargets.Property |
    AttributeTargets.Struct,
    AllowMultiple = false,
    Inherited = false
)]
public class RequiredMemberAttribute : Attribute 
{  
    
}

[AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
public class CompilerFeatureRequiredAttribute : Attribute
{
    public CompilerFeatureRequiredAttribute(string _) { }
}
#endif
