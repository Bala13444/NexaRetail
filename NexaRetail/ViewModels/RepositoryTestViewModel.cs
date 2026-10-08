using NexaRetail.Commands;
using NexaRetail.Repositories;
using System.Windows;
using System.Windows.Input;

namespace NexaRetail.ViewModels
{
    public class RepositoryTestViewModel : BaseViewModel
    {
        public ICommand TestUserCommand { get; }

        public RepositoryTestViewModel()
        {
            TestUserCommand =
                new RelayCommand(TestUser);
        }

        private void TestUser()
        {
            UserRepository repository =
                new UserRepository();

            var user = repository.GetUser(
                "admin",
                "TEMP_PASSWORD_HASH");

            if (user == null)
            {
                MessageBox.Show(
                    "User not found.",
                    "NexaRetail",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);

                return;
            }

            MessageBox.Show(
                "User found!\n\n" +
                "User Name: " + user.UserName + "\n" +
                "Full Name: " + user.FullName + "\n" +
                "Role: " + user.RoleName,
                "NexaRetail",
                MessageBoxButton.OK,
                MessageBoxImage.Information);
        }
    }
}