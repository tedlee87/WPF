using FolderModel;

namespace Repository.Interface
{
    public interface IFolderService
    {
        IEnumerable<FolderStructure> GetDrives();
        public IEnumerable<FolderStructure> GetFoldeStructures(string path);
    }
}