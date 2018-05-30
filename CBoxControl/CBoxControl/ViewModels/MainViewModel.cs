using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CBoxControl.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _rememberMe;
        private string _mainText;

        public bool RememberMe { get { return _rememberMe; } set { _rememberMe = value; OnPropertyChanged("RememberMe"); } }

        public string MainText { get { return _mainText; } set { _mainText = value; OnPropertyChanged("MainText"); } }

        public ICommand BtnCmd { get; set; }

        public MainViewModel()
        {
            RememberMe = false;
            BtnCmd = new Command(Btn_Clicked);
        }

        private void Btn_Clicked(object obj)
        {
            MainText = RememberMe ? "You are remembered!" : "You are not remembered :(";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName]string propertyName = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
