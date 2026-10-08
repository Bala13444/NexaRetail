using System;
using System.Windows;
using System.Windows.Input;
using NexaRetail.Commands;
using NexaRetail.Models;
using NexaRetail.Services;

namespace NexaRetail.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string _userName;
        private string _password;
        private bool _rememberMe;
        private bool _isBusy;

        private readonly AuthenticationService _authenticationService;

        public event Action LoginSucceeded;

        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                if (_userName != value)
                {
                    _userName = value;

                    OnPropertyChanged(nameof(UserName));

                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                if (_password != value)
                {
                    _password = value;

                    OnPropertyChanged(nameof(Password));

                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public bool RememberMe
        {
            get
            {
                return _rememberMe;
            }
            set
            {
                if (_rememberMe != value)
                {
                    _rememberMe = value;

                    OnPropertyChanged(nameof(RememberMe));
                }
            }
        }

        public bool IsBusy
        {
            get
            {
                return _isBusy;
            }
            set
            {
                if (_isBusy != value)
                {
                    _isBusy = value;

                    OnPropertyChanged(nameof(IsBusy));

                    CommandManager.InvalidateRequerySuggested();
                }
            }
        }

        public ICommand LoginCommand
        {
            get;
        }

        public LoginViewModel()
        {
            _authenticationService = new AuthenticationService();

            LoginCommand = new RelayCommand(
                ExecuteLogin,
                CanExecuteLogin);
        }

        private bool CanExecuteLogin()
        {
            return !IsBusy &&
                   !string.IsNullOrWhiteSpace(UserName) &&
                   !string.IsNullOrWhiteSpace(Password);
        }

        private void ExecuteLogin()
        {
            if (IsBusy)
            {
                return;
            }

            try
            {
                IsBusy = true;

                if (string.IsNullOrWhiteSpace(UserName))
                {
                    MessageBox.Show(
                        "Please enter username.",
                        "Login",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    return;
                }

                if (string.IsNullOrWhiteSpace(Password))
                {
                    MessageBox.Show(
                        "Please enter password.",
                        "Login",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);

                    return;
                }

                User user = _authenticationService.Login(
                    UserName,
                    Password);

                if (user != null)
                {
                    LoginSucceeded?.Invoke();

                    return;
                }

                MessageBox.Show(
                    "Invalid username or password.",
                    "Login Failed",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Unable to login.\n\n" + ex.Message,
                    "Login Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}