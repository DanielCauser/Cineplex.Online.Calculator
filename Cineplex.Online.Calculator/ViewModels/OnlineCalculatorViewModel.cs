using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Cineplex.Online.Calculator.Models;
using Xamarin.Forms;

namespace Cineplex.Online.Calculator.ViewModels
{
    public class OnlineCalculatorViewModel : BaseViewModel
    {
        double length;
        public string Length
        {
            get { return length == 0 ? string.Empty : length.ToString(); }
            set
            {
                if (double.TryParse(value, out length))
                {
                    length = double.Parse(value);
                    OnPropertyChanged();
                }
            }
        }
        double width;
        public string Width
        {
            get { return width == 0 ? string.Empty : width.ToString(); }
            set
            {
                if (double.TryParse(value, out width))
                    OnPropertyChanged();
            }
        }
        double height;
        public string Height
        {
            get { return height == 0 ? string.Empty : height.ToString(); }
            set
            {
                if (double.TryParse(value, out height))
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
                   var container = new ShippingContainerModel(length, width, height);
                   Result = container.AmountOfCartonsThatFitInContainer.ToString();
               }
               catch (Exception ex)
               {
                    await App.Current.MainPage.DisplayAlert("Attention!", ex.Message, "OK");
               }
               
               Busy = false;
           });
        }
    }
}
