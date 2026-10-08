using System.Windows.Input;
using NexaRetail.Commands;

namespace NexaRetail.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private readonly MainViewModel _mainViewModel;


        // =========================================================
        // COMMANDS
        // =========================================================

        public ICommand DashboardCommand { get; }

        public ICommand SalesCommand { get; }


        // =========================================================
        // CONSTRUCTOR
        // =========================================================

        public DashboardViewModel(
            MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;

            DashboardCommand =
                new RelayCommand(
                    ShowDashboard);

            SalesCommand =
                new RelayCommand(
                    ShowSales);
        }


        // =========================================================
        // DASHBOARD
        // =========================================================

        private void ShowDashboard()
        {
            _mainViewModel.ShowDashboard();
        }


        // =========================================================
        // SALES
        // =========================================================

        private void ShowSales()
        {
            _mainViewModel.ShowSales();
        }
    }
}