using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace TemplateWebAPI.Models;

public readonly struct Days : IParsable<Days>
{
    public int From { get; }
    public int To { get; }

    public Days(int from, int to)
    {
        From = from;
        To = to;
    }

    public static Days Parse(string value, IFormatProvider? provider)
    {
        if (!TryParse(value, provider, out var result))
        {
            throw new ArgumentException("Could not parse supplied value", nameof(value));
        }

        return result;
    }

    public static bool TryParse([NotNullWhen(true)] string? value, IFormatProvider? provider, out Days result)
    {
        if (value is not null)
        {
            var separator = value.IndexOf('-');
            if (separator > 0 && separator < value.Length - 1)
            {
                var fromSpan = value.AsSpan()[..separator];
                var toSpan = value.AsSpan(separator + 1);

                if (int.TryParse(fromSpan, NumberStyles.None, provider, out var from) 
                    && int.TryParse(toSpan, NumberStyles.None, provider, out var to))
                {
                    result = new Days(from, to);
                    return true;
                }
            }
        }
        result = default;
        return false;
    }
}