namespace FolderModel
{
    public class Folder
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Parent { get; set; }
        public FolderType FolderType { get; set; }
        public IList<Folder> Children { get; set; }
        public IList<string> Files { get; set; }
    }

    
}