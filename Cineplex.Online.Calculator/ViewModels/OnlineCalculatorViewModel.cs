using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Cineplex.Online.Calculator.Models;
using Xamarin.Forms;

namespace Cineplex.Online.Calculator.ViewModels
{
    public class OnlineCalculatorViewModel : BaseViewModel
    {
        string length;
        public string Length
        {
            get { return length; }
            set
            {
                Result = "0";
                length = value;
                OnPropertyChanged();
            }
        }
        string width;
        public string Width
        {
            get { return width; }
            set
            {
                width = value;
                Result = "0";
                OnPropertyChanged();
            }
        }
        string height;
        public string Height
        {
            get { return height; }
            set
            {
                height = value;
                Result = "0";
                OnPropertyChanged();
            }
        }

        double result;
        public string Result
        {
            get { return result == 0 ? string.Empty : $"A total of {result} carton(s) fit in the container."; }
            set
            {
                if (double.TryParse(value, out result))
                    OnPropertyChanged();
            }
        }

        public ICommand CalculateCommand { get; set; }

        public OnlineCalculatorViewModel() : base("Shipping container calculation")
        {
            CalculateCommand = new Command(async () =>
           {
               if (Busy) return;
               Busy = true;
               try
               {
                   validateViewData();
                    var container = new ShippingContainerModel(double.Parse(length)
                                                              , double.Parse(width)
                                                              , double.Parse(height));
                   Result = container.AmountOfCartonsThatFitInContainer.ToString();
               }
               catch (Exception ex)
               {
                   await App.Current.MainPage.DisplayAlert("Attention!", ex.Message, "OK");
               }

               Busy = false;
           });
        }

        private void validateViewData()
        {
			double len;
			double wid;
			double hei;
            StringBuilder errorMessage = new StringBuilder(string.Empty);
            if (!double.TryParse(length, out len))
                errorMessage.AppendLine($"Container's length must be a number.");
            if (!double.TryParse(width, out wid))
                errorMessage.AppendLine($"Container's width must be a number.");
            if (!double.TryParse(height, out hei))
                errorMessage.AppendLine($"Container's height must be a number.");
			if (!string.IsNullOrEmpty(errorMessage.ToString()))
				throw new Exception(errorMessage.ToString());
        }
    }
}
