using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Linq.Expressions;

namespace Data.Conversors;

internal class LongConversor : ValueConverter<decimal, long>
{
    private static readonly Expression<Func<decimal, long>> ConvertTo = (value) => (long)Math.Truncate(value * 100);
    private static readonly Expression<Func<long, decimal>> ConvertFrom = (value) => Math.Truncate((decimal)value / 100);

    public LongConversor()
        : base(ConvertTo, ConvertFrom)
    {
    }
}