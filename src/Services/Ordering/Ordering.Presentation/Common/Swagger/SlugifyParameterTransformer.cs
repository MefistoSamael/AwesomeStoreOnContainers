using System.Text.RegularExpressions;

namespace Ordering.Presentation.Common.Swagger;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        if (value is not null)
        {
            return Regex.Replace(
            value.ToString()!,
            "([a-z])([A-Z])",
            "$1-$2",
            RegexOptions.CultureInvariant,
            TimeSpan.FromMilliseconds(100)).ToLowerInvariant();
        }

        return null;
    }
}