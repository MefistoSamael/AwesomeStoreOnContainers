﻿using System.Text.RegularExpressions;

namespace Catalog.Presentation.Common.Swagger;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        return value == null
            ? null
            : Regex.Replace(
                value.ToString() !,
                "([a-z])([A-Z])",
                "$1-$2",
                RegexOptions.CultureInvariant,
                TimeSpan.FromMilliseconds(100)).ToLowerInvariant();
    }
}