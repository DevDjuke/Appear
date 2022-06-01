using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services
{
    public static class AssetManager
    {
        public static void AddAsset(string assetPath)
        {
            if (!HasAssets())
                Properties.Settings.Default.Assets = new System.Collections.Specialized.StringCollection();

            if (!Properties.Settings.Default.Assets.Contains(assetPath))
                Properties.Settings.Default.Assets.Add(assetPath);

            Properties.Settings.Default.Save();
        }

        public static void RemoveAsset(string assetPath)
        {
            if(Properties.Settings.Default.Assets.Contains(assetPath))
                Properties.Settings.Default.Assets.Remove(assetPath);

            Properties.Settings.Default.Save();
        }

        public static bool HasAssets()
        {
            return Properties.Settings.Default.Assets != null
                && Properties.Settings.Default.Assets.Count > 0;
        }
    }
}
