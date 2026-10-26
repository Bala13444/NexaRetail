using System.Windows.Controls;
using NexaRetail.ViewModels;

namespace NexaRetail.Views
{
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();

            DataContext = new DashboardViewModel();
        }
    }
}