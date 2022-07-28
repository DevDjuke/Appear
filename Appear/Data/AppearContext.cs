using Appear.Data.DO;
using Appear.Data.DTO;
using Appear.Domain;
using Appear.Domain.Settings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Data
{
    public class AppearContext : DbContext
    {
        public AppearContext() : base(new SQLiteConnection()
        {
            ConnectionString = new SQLiteConnectionStringBuilder()
            {
                DataSource = "C:\\Users\\joryj\\Desktop\\appeardb.db",
                ForeignKeys = true
            }.ConnectionString
        }, true)
        {
            
        }

        //public DbSet<Asset> Assets { get; set; }
        //public DbSet<AssetTag> AssetTags { get; set; }
        //public DbSet<FileType> FileTypes { get; set; }
        //public DbSet<MediaType> MediaTypes { get; set; }
        //public DbSet<Scene> Scenes { get; set; }
        //public DbSet<SceneAsset> SceneAssets { get; set; }
        //public DbSet<Tag> Tags { get; set; }

        public DbSet<ColorDTO> Colors { get; set; }
        public DbSet<StyleDTO> Styles { get; set; }

        public DbSet<UserSettingsDTO> UserSettings { get; set; }
        //public DbSet<AppSettings> AppSettings { get; set; }
    }
}
