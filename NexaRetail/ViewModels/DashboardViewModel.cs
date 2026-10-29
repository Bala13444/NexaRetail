using System.Windows.Input;
using NexaRetail.Commands;

namespace NexaRetail.ViewModels
{
    public class DashboardViewModel : BaseViewModel
    {
        private decimal _todaySales;
        private decimal _todayPurchase;
        private int _totalItems;
        private int _totalCustomers;

        public ICommand DashboardCommand { get; }
        public ICommand SalesCommand { get; }

        public decimal TodaySales
        {
            get { return _todaySales; }
            set
            {
                if (_todaySales != value)
                {
                    _todaySales = value;
                    OnPropertyChanged(nameof(TodaySales));
                }
            }
        }

        public decimal TodayPurchase
        {
            get { return _todayPurchase; }
            set
            {
                if (_todayPurchase != value)
                {
                    _todayPurchase = value;
                    OnPropertyChanged(nameof(TodayPurchase));
                }
            }
        }

        public int TotalItems
        {
            get { return _totalItems; }
            set
            {
                if (_totalItems != value)
                {
                    _totalItems = value;
                    OnPropertyChanged(nameof(TotalItems));
                }
            }
        }

        public int TotalCustomers
        {
            get { return _totalCustomers; }
            set
            {
                if (_totalCustomers != value)
                {
                    _totalCustomers = value;
                    OnPropertyChanged(nameof(TotalCustomers));
                }
            }
        }

        public DashboardViewModel()
        {
            TodaySales = 5580;
            TodayPurchase = 3120;
            TotalItems = 148;
            TotalCustomers = 36;
        }
    }
}