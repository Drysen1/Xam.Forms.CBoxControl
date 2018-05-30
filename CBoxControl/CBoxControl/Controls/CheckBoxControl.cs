using System;
using System.ComponentModel;
using Xamarin.Forms;

namespace CBoxControl.Controls
{
    public class CheckBoxControl : Image
    {
        private static string CheckboxUnCheckedImage = Device.RuntimePlatform == Device.UWP ? "Images/ic_checkbox_unchecked.png" : "ic_checkbox_unchecked.png";
        private static string CheckboxCheckedImage = Device.RuntimePlatform == Device.UWP ? "Images/ic_checkbox_checked.png" : "ic_checkbox_checked.png";

        public CheckBoxControl()
        {
            Source = CheckboxUnCheckedImage;
            var imageTapGesture = new TapGestureRecognizer();
            imageTapGesture.Tapped += ImageTapGestureOnTapped;
            GestureRecognizers.Add(imageTapGesture);
            PropertyChanged += OnPropertyChanged;
        }

        private void ImageTapGestureOnTapped(object sender, EventArgs eventArgs)
        {
            if (IsEnabled)
            {
                Checked = !Checked;
            }
        }

        /// <summary>
        /// The checked changed event.
        /// </summary>
        public event EventHandler<bool> CheckedChanged;

        /// <summary>
        /// The checked state property.
        /// </summary>
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create("Checked", typeof(bool), typeof(CheckBoxControl), false, BindingMode.TwoWay, propertyChanged: OnCheckedPropertyChanged);

        public bool Checked
        {
            get
            {
                return (bool)GetValue(CheckedProperty);
            }

            set
            {
                if (Checked != value)
                {
                    SetValue(CheckedProperty, value);
                    CheckedChanged?.Invoke(this, value);
                }
            }
        }

        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e?.PropertyName == IsEnabledProperty.PropertyName)
            {
                Opacity = IsEnabled ? 1 : 0.5;
            }
        }

        private static void OnCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var checkBox = bindable as CheckBoxControl;
            if (checkBox != null)
            {
                var value = newValue as bool?;
                checkBox.Checked = value.GetValueOrDefault();
                checkBox.Source = value.GetValueOrDefault() ? CheckboxCheckedImage : CheckboxUnCheckedImage;
            }
        }
    }
}
