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

        public static void DatabaseSetup()
        {
            SetConnection();
            SetTables();
        }

        private static void SetConnection()
        {
            conn = new SQLiteConnection("Data Source=appear.db; Version = 3; New = True; Compress = True; ");
        }

        private static void SetTables()
        {
            conn.Open();

            Execute(CreateTableSQL("Assets", "ID INT, path VARCHAR(250), FileType_Id INT, Folder_ID INT"));
            Execute(CreateTableSQL("AssetTags", "ID INT, Asset_Id INT, Tag_Id INT"));
            Execute(CreateTableSQL("Tags", "ID INT, Name VARCHAR(50)"));
            Execute(CreateTableSQL("FileTypes", "ID INT, Extension VARCHAR(10), MediaType_Id INT"));
            Execute(CreateTableSQL("MediaTypes", "ID INT, Name VARCHAR(50)"));
            Execute(CreateTableSQL("Folders", "ID INT, Path VARCHAR(250)"));

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
    }
}
