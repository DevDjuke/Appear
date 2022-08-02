using Appear.Data.Repos;
using Appear.Domain;
using Appear.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services.Data.Domain
{
    public static class AssetManager
    {
        public static void AddAsset(string name, string folderPath)
        {
            Folder folder = FolderRepository.Get(folderPath);
            if(folder == null)
            {
                folder = CreateFolder(folderPath);
            }

            AssetRepository.Add(new Asset()
            {
                Path = folderPath + "/" + name,
                FolderId = folder.Id,
                Name = name,
            });
        }

        private static Folder CreateFolder(string folderPath)
        {
            FolderRepository.Add(new Folder() { Path = folderPath});
            return FolderRepository.Get(folderPath);
        }

        public static void RemoveAsset(Asset asset)
        {
            List<SceneAssetDTO> sceneAssets = SceneAssetRepository.GetByAsset(asset.Id);
            if(sceneAssets != null)
            {
                foreach(SceneAssetDTO dto in sceneAssets)
                {
                    SceneAssetRepository.Remove(dto);
                }
            }

            List<AssetTagDTO> assetTags = AssetTagRepository.GetByAsset(asset.Id);
            if (sceneAssets != null)
            {
                foreach (AssetTagDTO dto in assetTags)
                {
                    AssetTagRepository.Remove(dto);
                }
            }

            AssetRepository.Remove(asset);
        }

        public static bool HasAssets()
        {
            return AssetRepository.HasAssets();
        }

        public static List<AssetCollection> Get()
        {
            List<AssetCollection> assets = new List<AssetCollection>();

            foreach (string folder in FolderManager.GetFolderPaths())
            {
                List<string> extensions = FileTypeManager.GetFileExtensions(MediaTypeManager.GetByType(MediaTypeDesc.Image));

                AssetCollection collection = new AssetCollection();
                collection.Path = folder;
                collection.Assets = new ObservableCollection<Asset>();

                foreach (string path in Directory.EnumerateFiles(folder, "*.*", SearchOption.AllDirectories)
                        .Where(s => extensions.Any(ext => ext == Path.GetExtension(s))))
                {
                    collection.Assets.Add(new Asset
                    {
                        Path = path,
                        Name = path.Split('\\').Last()
                    });
                }

                assets.Add(collection);
            }

            return assets;
        }
    }
}
