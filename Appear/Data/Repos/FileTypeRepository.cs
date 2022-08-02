using Appear.Data.DTO;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public static class FileTypeRepository
    {
        public static List<FileType> GetByMediaType(int mediaTypeId)
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

        public static FileType ToFileType(this FileTypeDTO dto)
        {
            return new FileType()
            {
                Id = dto.Id,
                Extension = dto.Extension,
                MediaType = MediaTypeRepository.Get(dto.MediaTypeId)
            };
        }
    }
}
