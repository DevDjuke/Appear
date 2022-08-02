﻿using Appear.Data.Repos;
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
        private static AssetRepository _repository = null;
        private static AssetRepository repository()
        {
            if( _repository == null ) _repository = new AssetRepository();
            return _repository;
        }

        public static void AddAsset(string name, string folderPath)
        {
            Folder folder = FolderManager.GetOrCreate(folderPath);
            repository().Add(new Asset()
            {
                Path = folderPath + "/" + name,
                FolderId = folder.Id,
                Name = name,
            });
        }     

        public static void RemoveAsset(Asset asset)
        {
            SceneAssetManager.RemoveReferences(asset);
            AssetTagManager.RemoveReferences(asset);
            repository().Remove(asset);
        }

        public static bool HasAssets()
        {
            return repository().HasAssets();
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
