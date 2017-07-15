using System;
using System.Collections.Generic;
using Cineplex.Online.Calculator.ViewModels;
using Xamarin.Forms;

namespace Cineplex.Online.Calculator.Views
{
    public partial class OnlineCalculatorView : ContentPage
    {
        public OnlineCalculatorView()
        {
            InitializeComponent();
            BindingContext = new OnlineCalculatorViewModel();
        }
    }
}
