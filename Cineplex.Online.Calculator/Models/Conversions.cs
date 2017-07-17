using System;

namespace Cineplex.Online.Calculator.Models
{
    public static class Conversions
    {
        public static double ConvertFeetToInches(double feets)
        {
            return Math.Round(feets * 12, 2);
        }

		public static double ConvertInchesToFeets(double inches)
		{
            return Math.Round(inches / 12, 2);
		}
    }
}
