using Cineplex.Online.Calculator.Views;
using Xamarin.Forms;

namespace Cineplex.Online.Calculator
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new OnlineCalculatorView());
        }
    }
}
