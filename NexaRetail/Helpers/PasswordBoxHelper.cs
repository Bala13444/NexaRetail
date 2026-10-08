using System.Windows;
using System.Windows.Controls;

namespace NexaRetail.Helpers
{
    public static class PasswordBoxHelper
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached(
                "Password",
                typeof(string),
                typeof(PasswordBoxHelper),
                new FrameworkPropertyMetadata(
                    string.Empty,
                    FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    PasswordChanged));

        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(
            DependencyObject obj,
            string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        private static void PasswordChanged(
            DependencyObject sender,
            DependencyPropertyChangedEventArgs e)
        {
            PasswordBox passwordBox =
                sender as PasswordBox;

            if (passwordBox == null)
            {
                return;
            }

            passwordBox.PasswordChanged -=
                PasswordBox_PasswordChanged;

            if (passwordBox.Password != e.NewValue?.ToString())
            {
                passwordBox.Password =
                    e.NewValue?.ToString() ?? string.Empty;
            }

            passwordBox.PasswordChanged +=
                PasswordBox_PasswordChanged;
        }

        private static void PasswordBox_PasswordChanged(
            object sender,
            RoutedEventArgs e)
        {
            PasswordBox passwordBox =
                sender as PasswordBox;

            if (passwordBox == null)
            {
                return;
            }

            SetPassword(
                passwordBox,
                passwordBox.Password);
        }
    }
}