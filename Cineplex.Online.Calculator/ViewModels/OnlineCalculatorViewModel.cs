using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
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
				OnPropertyChanged();
			}
		}

        public ICommand CalculateCommand { get; set; }

        public OnlineCalculatorViewModel() : base("Shipping container calculation")
        {
            CalculateCommand = new Command( async () =>
            {
                if (Busy) return;
                Busy = true;

                await Task.Delay(10000);

                Busy = false;
            });
        }
    }
}
