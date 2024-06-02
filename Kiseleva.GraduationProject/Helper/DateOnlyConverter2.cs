using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kiseleva.GraduationProject.Helper
{
	public class DateOnlyConverter2 : ValueConverter<DateOnly, DateTime>
	{
		public DateOnlyConverter2() : base(
			dateOnly => dateOnly.ToDateTime(TimeOnly.MinValue),
			dateTime => DateOnly.FromDateTime(dateTime))
		{ }
	}
}
