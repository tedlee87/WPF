using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FolderModel
{
    public class FolderStructure
    {
        public string FullPath { get; set; }
        public FolderType FolderType { get; set; }
        public IList<FolderStructure> Children { get; set; }
    }
}
