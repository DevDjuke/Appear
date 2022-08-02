using Appear.Data.DTO;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public class FileTypeRepository
    {
        public List<FileType> GetByMediaType(int mediaTypeId)
        {
            List<FileType> result = new List<FileType>();
            List<FileTypeDTO> fileTypes = null;

            using(var db = new AppearContext())
            {
                fileTypes = db.FileTypes.Where(x => x.MediaTypeId == mediaTypeId).ToList();
            }

            if(fileTypes != null)
            {
                foreach(var fileType in fileTypes)
                {
                    result.Add(fileType.ToFileType());
                }
            }

            return result;
        }
    }
}
