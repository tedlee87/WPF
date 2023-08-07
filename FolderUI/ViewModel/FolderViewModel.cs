using FolderModel;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class FolderViewModel : BaseViewModel
    {
        private readonly IFolderService _folderService;
        public ObservableCollection<FolderStructureViewModel> Items { get; set; }

        //public Folder Current { get; }

        public FolderViewModel(IFolderService folderService)
        {
            Items = new ObservableCollection<FolderStructureViewModel>(folderService.GetDrives().Select(d => new FolderStructureViewModel(folderService) { FullPath = d.FullPath, FolderType = d.FolderType, Children = new ObservableCollection<FolderStructureViewModel>() { null } }));
            _folderService = folderService;
        }

    }
}
