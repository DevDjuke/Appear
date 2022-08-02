using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public static class AssetTagRepository
    {
        public static void Add(AssetTagDTO dto)
        {
            using (var db = new AppearContext())
            {
                db.AssetTags.Add(dto);
            }
        }

        public static void Remove(AssetTagDTO dto)
        {
            using (var db = new AppearContext())
            {
                db.AssetTags.Remove(dto);
            }
        }

        public static List<AssetTagDTO> GetByAsset(int assetId)
        {
            using (var db = new AppearContext())
            {
                return db.AssetTags.Where(x => x.AssetId == assetId).ToList();
            }
        }
    }
}
