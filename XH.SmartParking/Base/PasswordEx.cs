using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace XH.SmartParking.Base
{
    public class PasswordEx
    {
        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        // Using a DependencyProperty as the backing store for Password.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordEx), new PropertyMetadata("******", new PropertyChangedCallback(OnPropertyChanged)));


        static bool _isUpdating = false;

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox pd = (PasswordBox)d;
            pd.PasswordChanged -= Pd_PasswordChanged;
            if (!_isUpdating)
                pd.Password = e.NewValue.ToString();
            pd.PasswordChanged += Pd_PasswordChanged;
        }

        private static void Pd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox pd = (PasswordBox)sender;
            _isUpdating = true;
            SetPassword(pd, pd.Password);
            _isUpdating = false;
        }
    }
}
