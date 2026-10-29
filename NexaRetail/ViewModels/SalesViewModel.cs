using System;
using System.Collections.ObjectModel;
using System.Linq;
using NexaRetail.Models;

namespace NexaRetail.ViewModels
{
    public class SalesViewModel : BaseViewModel
    {
        private decimal _todaySales;
        private int _invoiceCount;
        private int _pendingCount;
        private decimal _paidAmount;

        public ObservableCollection<Sale> Sales { get; }

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

        public int InvoiceCount
        {
            get { return _invoiceCount; }
            set
            {
                if (_invoiceCount != value)
                {
                    _invoiceCount = value;
                    OnPropertyChanged(nameof(InvoiceCount));
                }
            }
        }

        public int PendingCount
        {
            get { return _pendingCount; }
            set
            {
                if (_pendingCount != value)
                {
                    _pendingCount = value;
                    OnPropertyChanged(nameof(PendingCount));
                }
            }
        }

        public decimal PaidAmount
        {
            get { return _paidAmount; }
            set
            {
                if (_paidAmount != value)
                {
                    _paidAmount = value;
                    OnPropertyChanged(nameof(PaidAmount));
                }
            }
        }

        public SalesViewModel()
        {
            Sales = new ObservableCollection<Sale>
            {
                new Sale
                {
                    InvoiceNo = "INV-1001",
                    SaleDate = new DateTime(2026, 10, 29),
                    CustomerName = "Ramesh Stores",
                    ItemName = "Rice 25kg",
                    Quantity = 2,
                    Amount = 2400,
                    PaymentMode = "Cash",
                    Status = "Paid"
                },
                new Sale
                {
                    InvoiceNo = "INV-1002",
                    SaleDate = new DateTime(2026, 10, 29),
                    CustomerName = "Priya Mart",
                    ItemName = "Cooking Oil",
                    Quantity = 12,
                    Amount = 3180,
                    PaymentMode = "UPI",
                    Status = "Paid"
                },
                new Sale
                {
                    InvoiceNo = "INV-1003",
                    SaleDate = new DateTime(2026, 10, 28),
                    CustomerName = "Kumar Traders",
                    ItemName = "Sugar",
                    Quantity = 10,
                    Amount = 4500,
                    PaymentMode = "Credit",
                    Status = "Pending"
                },
                new Sale
                {
                    InvoiceNo = "INV-1004",
                    SaleDate = new DateTime(2026, 10, 28),
                    CustomerName = "Anitha Super Market",
                    ItemName = "Atta 10kg",
                    Quantity = 8,
                    Amount = 2880,
                    PaymentMode = "Cash",
                    Status = "Paid"
                },
                new Sale
                {
                    InvoiceNo = "INV-1005",
                    SaleDate = new DateTime(2026, 10, 27),
                    CustomerName = "Green Basket",
                    ItemName = "Toor Dal",
                    Quantity = 15,
                    Amount = 2250,
                    PaymentMode = "UPI",
                    Status = "Paid"
                },
                new Sale
                {
                    InvoiceNo = "INV-1006",
                    SaleDate = new DateTime(2026, 10, 27),
                    CustomerName = "City Grocery",
                    ItemName = "Tea Powder",
                    Quantity = 6,
                    Amount = 1620,
                    PaymentMode = "Card",
                    Status = "Paid"
                },
                new Sale
                {
                    InvoiceNo = "INV-1007",
                    SaleDate = new DateTime(2026, 10, 26),
                    CustomerName = "Lakshmi Stores",
                    ItemName = "Ghee 1L",
                    Quantity = 4,
                    Amount = 3200,
                    PaymentMode = "Credit",
                    Status = "Pending"
                },
                new Sale
                {
                    InvoiceNo = "INV-1008",
                    SaleDate = new DateTime(2026, 10, 26),
                    CustomerName = "Fresh Mart",
                    ItemName = "Milk Pack",
                    Quantity = 24,
                    Amount = 1440,
                    PaymentMode = "UPI",
                    Status = "Paid"
                }
            };

            DateTime today = new DateTime(2026, 10, 29);

            TodaySales = Sales
                .Where(sale => sale.SaleDate.Date == today)
                .Sum(sale => sale.Amount);

            InvoiceCount = Sales.Count;

            PendingCount = Sales.Count(sale => sale.Status == "Pending");

            PaidAmount = Sales
                .Where(sale => sale.Status == "Paid")
                .Sum(sale => sale.Amount);
        }
    }
}
