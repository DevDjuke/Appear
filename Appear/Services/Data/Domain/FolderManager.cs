using Appear.Data.Repos;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class FolderManager
    {
        public static bool HasFolders()
        {
            return FolderRepository.Count() > 0 ;
        }

        public static List<string> GetFolderPaths()
        {
            List<string> paths = new List<string>();
            List<Folder> folders = FolderRepository.GetAll();

            foreach (Folder folder in folders)
            {
                paths.Add(folder.Path);
            }

            return paths;
        }

        public static void Add(string path)
        {
            FolderRepository.Add(new Folder() { Path = path });
        }

        public static void Remove(string path)
        {
            Folder folder = FolderRepository.Get(path);
            FolderRepository.Remove(folder);
        }
    }
}
