using System;
using System.Text;

namespace Cineplex.Online.Calculator.Models
{
    public class ShippingContainerModel
    {
        private readonly double LengthCarton = 18;
        private readonly double WidthCarton = 18;
        private readonly double HeightCarton = 8;

        public double Length { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public double AmountOfCartonsThatFitInContainer { get; private set; }

        public ShippingContainerModel(double length, double width, double height)
        {
            Length = Conversions.ConvertFeetToInches(length);
            Width = Conversions.ConvertFeetToInches(width);
            Height = Conversions.ConvertFeetToInches(height);
            CalculateAmountOfCartonsThatFitInContainer();
        }

        public void CalculateAmountOfCartonsThatFitInContainer()
        {
            validateContainer();

            AmountOfCartonsThatFitInContainer =
                Math.Round(
                    (Length / LengthCarton) *
                    (Width / WidthCarton) *
                    (Height / HeightCarton), 0);
        }

        private void validateContainer()
        {
            StringBuilder errorMessage = new StringBuilder(string.Empty);
            if (Length < LengthCarton)
                errorMessage.AppendLine($"Container's lenght needs to be equal or greater than {Conversions.ConvertInchesToFeets(LengthCarton)}feets.");
			if (Width < WidthCarton)
                errorMessage.AppendLine($"Container's width needs to be equal or greater than {Conversions.ConvertInchesToFeets(WidthCarton)}feets.");
			if (Height < HeightCarton)
                errorMessage.AppendLine($"Container's height needs to be equal or greater than {Conversions.ConvertInchesToFeets(HeightCarton)}feets.");

            if (!string.IsNullOrEmpty(errorMessage.ToString()))
                throw new Exception(errorMessage.ToString());
        }
    }
}
