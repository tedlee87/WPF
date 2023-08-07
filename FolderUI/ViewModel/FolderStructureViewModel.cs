using FolderModel;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ViewModel.Commands;

namespace ViewModel
{
    public class FolderStructureViewModel : BaseViewModel
    {
        private readonly IFolderService _folderService;

        public string FullPath { get; set; }
        public string Name => FolderType == FolderType.Drive ? FullPath : Path.GetFileName(FullPath);
        public FolderType FolderType { get; set; }
        public ObservableCollection<FolderStructureViewModel> Children { get; set; }

        public FolderStructureViewModel(IFolderService folderService)
        {
            _folderService = folderService;
        }

        public bool CanExpand { get { return FolderType != FolderType.File; } }

        public bool IsExpanded
        {
            get
            {
                return Children?.Count(c => c != null) > 0;
            }
            set
            {
                if (value == true)
                    Expand();
                else
                {
                    this.ClearChildren();
                }
            }
        }


        private void ClearChildren()
        {
            Children = new ObservableCollection<FolderStructureViewModel>();
            if(FolderType != FolderType.File)
            {
                Children.Add(null);
            }
        }

        private void Expand()
        {
            if(FolderType == FolderType.File)
            {
                return;
            }
            var items = _folderService.GetFoldeStructures(FullPath).Select(fs => Create(fs.FullPath, fs.FolderType));
            Children = new ObservableCollection<FolderStructureViewModel>(items);
        }

        private FolderStructureViewModel Create(string fullPath, FolderType folderType)
        {
            return new FolderStructureViewModel(_folderService)
            {
                FullPath = fullPath,
                FolderType = folderType,
                Children = folderType == FolderType.Folder ? new ObservableCollection<FolderStructureViewModel>() { null } : new ObservableCollection<FolderStructureViewModel>()
            };
        }
    }
}
