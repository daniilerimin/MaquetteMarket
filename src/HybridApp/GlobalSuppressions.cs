
[assembly: System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage(
    "Trimming", 
    "IL2111", 
    Justification = "Blazor Router and LayoutView components use safe reflection patterns that are preserved by the MAUI build process.")]

[assembly: System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessage(
    "Trimming", 
    "IL2110", 
    Justification = "Blazor LayoutView internal fields are accessed via reflection in a controlled manner that's safe for MAUI hybrid apps.")]