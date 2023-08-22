using CustomersApp.Model;

namespace CustomersApp.ViewModel
{
    public class CustomerItemViewModel : ValidationViewModelBase
    {
        private readonly Customer _model;
        public CustomerItemViewModel(Customer model)
        {
            _model = model;
        }

        public int Id => _model.Id;

        public string? FirstName
        {
            get => _model.FirstName;
            set 
            {
                _model.FirstName = value; 
                OnPropertyChanged();
                if(string.IsNullOrEmpty(_model.FirstName))
                {
                    AddErrors("FirstName is Required", nameof(FirstName));
                }
                else
                {
                    ClearErrors(nameof(FirstName));
                }
            }
        }

        public string? LastName
        {
            get => _model.LastName;
            set 
            { 
                _model.LastName = value;
                OnPropertyChanged();
            }
        }

        public bool IsDeveloper
        {
            get => _model.IsDeveloper;
            set
            {
                _model.IsDeveloper = value;
                OnPropertyChanged();
            }
        }

    }
}
