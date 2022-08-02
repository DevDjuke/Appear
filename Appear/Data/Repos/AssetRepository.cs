using Appear.Data.DTO;
using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data.Repos
{
    public class AssetRepository
    {
        public bool HasAssets()
        {
            bool result = false;

            using(var db = new AppearContext())
            {
                result = (db.Assets.Count() > 0);
            }

            return result;
        }

        public void Add(Asset asset)
        {
            using (var db = new AppearContext())
            {
                db.Assets.Add(asset.ToDTO());
            }
        }

        public void Remove(Asset asset)
        {
            using (var db = new AppearContext())
            {
                db.Assets.Remove(asset.ToDTO());
            }
        }
    }
}
