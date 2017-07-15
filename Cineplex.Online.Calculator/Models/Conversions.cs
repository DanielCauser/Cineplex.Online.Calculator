namespace Cineplex.Online.Calculator.Models
{
    public static class Conversions
    {
        public static double ConvertFeetToInches(double feets)
        {
            return feets * 12;
        }

		public static double ConvertInchesToFeets(double inches)
		{
			return inches / 12;
		}
    }
}
