using CustomersApp.Command;
using CustomersApp.Data;
using CustomersApp.Model;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CustomersApp.ViewModel
{
    public class CustomersViewModel : ViewModelBase
    {
        public ICustomerDataProvider _customerDataProvider { get; }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand MoveNavigationCommand { get; }
        public DelegateCommand DeleteCommand { get; }
        

        public CustomersViewModel(ICustomerDataProvider customerDataProvider)
        {
            _customerDataProvider = customerDataProvider;
            AddCommand = new DelegateCommand(Add);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        private CustomerItemViewModel _selectedCustomer;
        public CustomerItemViewModel SelectedCustomer 
        { 
            get => _selectedCustomer; 
            set 
            {
                _selectedCustomer = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsCustomerSelected));
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        private NavigationSide _navigationSide;
        public NavigationSide NavigationSide
        { 
            get => _navigationSide;
            private set
            {

                _navigationSide = value;
                OnPropertyChanged();
            }
        }

        public bool IsCustomerSelected => SelectedCustomer is not null;

        public async override Task LoadAsync()
        {
            if(Customers.Any())
            {
                return;
            }

            var customers = await _customerDataProvider.GetAllAsync();
            if(customers != null)
            {
                var customersItems = customers.Select(x => new CustomerItemViewModel(x));
                foreach(var customersItem in customersItems)
                {
                    Customers.Add(customersItem);
                }
            }
        }

        private void Add(object? parameter)
        {
            var customer = new CustomerItemViewModel(new Customer { FirstName = "New" });
            Customers.Add(customer);
            SelectedCustomer = customer;
        }

        private void MoveNavigation(object? parameter)
        {
            NavigationSide = NavigationSide == NavigationSide.Left ? NavigationSide .Right : NavigationSide.Left;
        }

        private void Delete(object? parameter)
        {
            if(SelectedCustomer is not null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        private bool CanDelete(object? parameter) => SelectedCustomer is not null;
    }

    public enum NavigationSide
    {
        Left = 0,
        Right = 2
    }
}
