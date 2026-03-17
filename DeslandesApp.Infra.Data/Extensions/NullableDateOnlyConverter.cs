using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeslandesApp.Infra.Data.Extensions
{
    public class NullableDateOnlyConverter : ValueConverter<DateOnly?, DateTime?>
    {
        public NullableDateOnlyConverter()
            : base(
                d => d.HasValue ? d.Value.ToDateTime(TimeOnly.MinValue) : null,
                d => d.HasValue ? DateOnly.FromDateTime(d.Value) : null)
        { }
    }

    public class NullableDateOnlyComparer : ValueComparer<DateOnly?>
    {
        public NullableDateOnlyComparer()
            : base(
                (d1, d2) => d1 == d2,
                d => d.HasValue ? d.Value.GetHashCode() : 0)
        { }
    }
}