using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Cineplex.Online.Calculator.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
		public BaseViewModel(string title)
		{
			Title = title;
		}

		private string title;
		public string Title
		{
			get { return title; }
			set
			{
				title = value;
				OnPropertyChanged();
			}
		}
        private bool busy;
		public bool Busy
		{
			get { return busy; }
			set
			{
				busy = value;
				OnPropertyChanged();
			}
		}

		private bool loading;
		public bool Loading
		{
			get { return loading; }
			set
			{
				loading = value;
				OnPropertyChanged();
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
		public void OnPropertyChanged([CallerMemberName]string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
