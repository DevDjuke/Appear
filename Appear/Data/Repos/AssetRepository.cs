using Appear.Data.DTO;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public static class AssetRepository
    {
        public static bool HasAssets()
        {
            bool result = false;

            using(var db = new AppearContext())
            {
                result = (db.Assets.Count() > 0);
            }

            return result;
        }

        public static void Add(Asset asset)
        {
            using (var db = new AppearContext())
            {
                db.Assets.Add(asset.ToDTO());
            }
        }

        public static void Remove(Asset asset)
        {
            using (var db = new AppearContext())
            {
                db.Assets.Remove(asset.ToDTO());
            }
        }

        public static AssetDTO ToDTO(this Asset asset)
        {
            return new AssetDTO()
            {

                FileTypeId = asset.FileTypeId,
                Id = asset.Id,
                Name = asset.Name
            };
        }
    }
}
