using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appear.Services
{
    public static class DataManager
    {
        static SQLiteConnection conn;

        private struct Tables
        {
            public static readonly string ASSETS = "Assets";
            public static readonly string ASSET_TAGS = "AssetTags";
            public static readonly string TAGS = "Tags";
            public static readonly string FOLDERS = "Folders";
            public static readonly string FILETYPES = "FileTypes";
            public static readonly string MEDIATYPES = "MediaTypes";
        }

        public static void DatabaseSetup()
        {
            SetConnection();
            CreateTables();
        }

        private static void DropTables()
        {
            conn.Open();

            Execute(DropTableSQL(Tables.ASSET_TAGS));
            Execute(DropTableSQL(Tables.ASSETS));
            Execute(DropTableSQL(Tables.TAGS));
            Execute(DropTableSQL(Tables.FOLDERS));
            Execute(DropTableSQL(Tables.FILETYPES));
            Execute(DropTableSQL(Tables.MEDIATYPES));

            conn.Close();
        }

        private static void SetConnection()
        {
            conn = new SQLiteConnection("Data Source=appear.db; Version = 3; New = True; Compress = True; ");
        }

        private static void CreateTables()
        {
            conn.Open();
        
            Execute(CreateTableSQL(Tables.MEDIATYPES, "ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
                                                 "Name VARCHAR(50) NOT NULL, "));

            Execute(CreateTableSQL(Tables.FILETYPES, "ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
                                                "Extension VARCHAR(10) NOT NULL, " +
                                                "MediaType_ID INT NOT NULL FOREIGN KEY REFERENCES MediaTypes(ID)"));

            Execute(CreateTableSQL(Tables.FOLDERS, "ID INT NOT NULL IDENTITY(1,1)PRIMARY KEY, " +
                                              "Path VARCHAR(250) NOT NULL,"));       

            Execute(CreateTableSQL(Tables.TAGS, "ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
                                           "Name VARCHAR(50)"));

            Execute(CreateTableSQL(Tables.ASSETS, "ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
                                             "Path VARCHAR(250) NOT NULL, " +
                                             "Name VARCHAR(100) NOT NULL," +
                                             "FileType_ID INT NOT NULL FOREIGN KEY REFERENCES FileTypes(ID), " +
                                             "Folder_ID INT NOT NULL FOREIGN KEY REFERENCES Folders(ID)"));

            Execute(CreateTableSQL(Tables.ASSET_TAGS, "ID INT NOT NULL IDENTITY(1,1) PRIMARY KEY, " +
                                                "Asset_ID INT NOT NULL FOREIGN KEY REFERENCES Assets(ID), " +
                                                "Tag_ID INT NOT NULL FOREIGN KEY REFERENCES Tags(ID),"));

            conn.Close();
        }

        private static void Execute(string sql)
        {
            SQLiteCommand cmd = new SQLiteCommand(sql, conn);
            cmd.ExecuteNonQuery();
        }

        private static string CreateTableSQL(string name, string columns)
        {
            return String.Format("CREATE TABLE IF NOT EXISTS {0} ({1})", name, columns);
        }

        private static string InsertIntoTableSQL(string table, string columns, string vlaues)
        {
            return String.Format("INSERT INTO {0} ({1}) VALUES ({2}", table, columns, vlaues);
        }

        private static string DropTableSQL(string table)
        {
            return String.Format("DROP TABLE {0}", table);
        }

        public static void CreateScene(Scene scene)
        {
            conn.Open();
            Execute(InsertIntoTableSQL(Tables.TAGS, "Name", scene.Name));
            conn.Close();
        }

        public static void CreateAsset(Asset asset)
        {
            conn.Open();
            string values = String.Format("{0},{1},{2},{3}", asset.Path, asset.FileTypeId, asset.FolderId, asset.Name); 
            Execute(InsertIntoTableSQL(Tables.ASSETS, "Path, FileType_ID, Folder_ID, Name", values));
            conn.Close();
        }

        public static void AddAssetToScene(Scene scene, Asset asset)
        {
            conn.Open();

            string values = String.Format("{0},{1}", asset.Id, scene.Id);
            Execute(InsertIntoTableSQL(Tables.ASSETS, "Asset_ID, Tag_ID", values));

            conn.Close();
        }
    }
}
