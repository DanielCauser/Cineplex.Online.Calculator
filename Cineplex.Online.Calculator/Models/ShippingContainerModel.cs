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
            Length = length;
            Width = width;
            Height = height;
            CalculateAmountOfCartonsThatFitInContainer();
        }

        public void CalculateAmountOfCartonsThatFitInContainer()
        {
            validateContainer();

            AmountOfCartonsThatFitInContainer = 
                (Length / LengthCarton) *
                (Width / WidthCarton) *
                (Height / HeightCarton);
        }

        private void validateContainer()
        {
            StringBuilder errorMessage = new StringBuilder(string.Empty);
            if (Length < LengthCarton)
                errorMessage.AppendLine($"Container's lenght needs to be equal or greater than {LengthCarton}in.");
			if (Width < WidthCarton)
                errorMessage.AppendLine($"Container's width needs to be equal or greater than {WidthCarton}in.");
			if (Height < HeightCarton)
                errorMessage.AppendLine($"Container's height needs to be equal or greater than {HeightCarton}in.");

            if (!string.IsNullOrEmpty(errorMessage.ToString()))
                throw new Exception(errorMessage.ToString());
        }
    }
}
