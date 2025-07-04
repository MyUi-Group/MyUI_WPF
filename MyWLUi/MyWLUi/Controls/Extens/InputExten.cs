using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

using System.Windows.Controls.Primitives;

namespace MyWLUi.Controls
{
    /// <summary>
    /// LCL
    /// Element附件属性
    /// </summary>
    public class InputExten : DependencyObject
    {
        internal static bool GetIsPassword(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPasswordProperty);
        }

        internal static void SetIsPassword(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPasswordProperty, value);
        }
        // Using a DependencyProperty as the backing store for IsPassword.  This enables animation, styling, binding, etc...
        internal static readonly DependencyProperty IsPasswordProperty =
            DependencyProperty.RegisterAttached("IsPassword", typeof(bool), typeof(InputExten), new PropertyMetadata(OnIsPasswordChanged));

        private static void OnIsPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox password)
            {
                if (GetIsPassword(password))
                {
                    password.PasswordChanged += Password_PasswordChanged;
                }
                else
                {
                    password.PasswordChanged -= Password_PasswordChanged;
                }
            }
        }

        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(InputExten), new PropertyMetadata(OnPasswordChanged));

        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox = d as PasswordBox;
            string password = (string)e.NewValue;
            if (passwordBox != null && passwordBox.Password != password)
            {
                passwordBox.Password = password;
            }

            var _ToggleButton = passwordBox.Template?.FindName("PART_ToggleButton", passwordBox) as ToggleButton;
            if (_ToggleButton != null)
            {
                _ToggleButton.Checked -= ExcuteToggleButtonChecked;
                _ToggleButton.Checked += ExcuteToggleButtonChecked;
            }
        }

        private static void ExcuteToggleButtonChecked(object sender, RoutedEventArgs e)
        {
            ToggleButton _tBtn = sender as ToggleButton;
            if (_tBtn != null)
            {
                if (_tBtn.Tag is PasswordBox password)
                {
                    var _TextBlock = password.Template?.FindName("ShowPassword_TextBox", password) as TextBlock;
                    _TextBlock.Text = password.Password;
                }
            }
        }


        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            string password = GetPassword(passwordBox);
            if (passwordBox != null && passwordBox.Password != password)
            {
                SetPassword(passwordBox, passwordBox.Password);
            }
        }
    }
}
