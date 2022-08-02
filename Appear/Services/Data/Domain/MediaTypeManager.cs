using Appear.Data.Repos;
using Appear.Domain;
using Appear.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class MediaTypeManager
    {
        public static MediaType GetByType(MediaTypeDesc type)
        {
            return MediaTypeRepository.Get(type.ToString());
        }
    }
}
