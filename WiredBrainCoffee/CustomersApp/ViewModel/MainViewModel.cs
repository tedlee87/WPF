﻿using CustomersApp.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomersApp.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
		private ViewModelBase? _selectedViewModel;

        public MainViewModel(CustomersViewModel customersViewModel, ProductsViewModel productsViewModel)
        {
            CustomersViewModel = customersViewModel;
			ProductsViewModel = productsViewModel;
			SelectedViewModel = CustomersViewModel;
			SelectViewModelCommand = new DelegateCommand(SelectViewModel);
        }

        public ViewModelBase? SelectedViewModel
		{
			get => _selectedViewModel;
			set 
			{ 
				_selectedViewModel = value; 
				OnPropertyChanged();
			}
        }
        public CustomersViewModel CustomersViewModel { get; }
        public ProductsViewModel? ProductsViewModel { get; }
        public DelegateCommand SelectViewModelCommand { get; }

        public async override Task LoadAsync()
		{
			if(SelectedViewModel != null)
			{
				await SelectedViewModel.LoadAsync();
			}
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }
    }
}
