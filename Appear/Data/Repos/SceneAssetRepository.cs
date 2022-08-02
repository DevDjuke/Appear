using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public static class SceneAssetRepository
    {
        public static void Add(SceneAssetDTO dto)
        {
            using(var db = new AppearContext())
            {
                db.SceneAssets.Add(dto);
            }
        }

        public static void Remove(SceneAssetDTO dto)
        {
            using (var db = new AppearContext())
            {
                db.SceneAssets.Remove(dto);
            }
        }

        public static List<SceneAssetDTO> GetByAsset(int assetId)
        {
            using (var db = new AppearContext())
            {
                return db.SceneAssets.Where(x => x.AssetId == assetId).ToList();
            }
        }
    }
}
