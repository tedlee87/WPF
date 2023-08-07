using FolderModel;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class FolderService : IFolderService
    {
        public IEnumerable<FolderStructure> GetDrives()
        {
            var localDrives = DriveInfo.GetDrives();
            return localDrives.Select(ld => 
                new FolderStructure 
                { 
                    FolderType = FolderType.Drive,
                    FullPath =  ld.Name, 
                    Children = new List<FolderStructure>() 
                });
        }

        public IEnumerable<FolderStructure> GetFoldeStructures(string path)
        {
            var directories = Directory.GetDirectories(path);
            var result = new List<FolderStructure>();
            foreach(var dir in directories)
            {
                var attribute = File.GetAttributes(dir);
                if(attribute.HasFlag(FileAttributes.Directory) && !attribute.HasFlag(FileAttributes.Hidden))
                {

                    result.Add(new FolderStructure { FullPath = dir, FolderType = FolderType.Folder });
                }
                
            }

            var files = Directory.GetFiles(path);
            foreach(var file in files)
            {
                var attribute = File.GetAttributes(file);
                if(!attribute.HasFlag(FileAttributes.Directory) && !attribute.HasFlag(FileAttributes.Hidden))
                {
                    result.Add(new FolderStructure { FullPath = file,  FolderType = FolderType.File });
                }
            }
            return result;
        }
    }
}
