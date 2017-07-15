using System;
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

        private double volumeOfCarton { get; set; }
        private double volumeOfContainer { get; set; }

        public double AmountOfCartonsThatFitInContainer { get; private set; }

        public ShippingContainerModel(double length, double width, double height)
        {
            Length = length;
            Width = width;
            Height = height;
        }

        public void CalculateAmountOfCartonsThatFitInContainer()
        {
            calculateVolumeOfCarton();
            calculateVolumeOfContainer();
        }

        private void calculateVolumeOfCarton()
        {
            
        }

		private void calculateVolumeOfContainer()
		{

		}
    }
}
