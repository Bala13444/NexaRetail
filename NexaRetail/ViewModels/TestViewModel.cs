using System.Windows.Input;
using NexaRetail.Commands;

namespace NexaRetail.ViewModels
{
    public class TestViewModel : BaseViewModel
    {
        public ICommand TestCommand { get; }

        public TestViewModel()
        {
            TestCommand = new RelayCommand(Test);
        }

        private void Test()
        {
            System.Windows.MessageBox.Show(
                "Command executed successfully!");
        }
    }
}