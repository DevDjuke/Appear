using Appear.Data.Repos;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class FileTypeManager
    {
        public static List<string> GetFileExtensions(MediaType mediaType)
        {
            List<string> extensions = new List<string>();
            var filetypes = FileTypeRepository.GetByMediaType(mediaType.Id);

            foreach (var filetype in filetypes)
            {
                extensions.Add(filetype.Extension);
            }

            return extensions;
        }
    }
}
