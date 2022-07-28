using Appear.Domain;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Appear.Services.Data.DataManager;

namespace Appear.Data.Repos
{
    public class SceneRepository
    {
        //SQLiteConnection conn;

        //public SceneRepository(SQLiteConnection conn)
        //{
        //    this.conn = conn;
        //}

        //public void CreateScene(Scene scene)
        //{
        //    conn.Open();
        //    Execute(InsertIntoTableSQL(Tables.SCENES, "Name", scene.Name));
        //    conn.Close();
        //}

        //public void DeleteScene(Scene scene)
        //{
        //    conn.Open();
        //    Execute(DeleteFromTableByIdSQL(Tables.SCENES, scene.Id));
        //    conn.Close();
        //}

        //public Scene GetSceneByName(string name)
        //{
        //    conn.Open();
        //    Scene result = (Scene)ExecuteReturnSingle(GetFromTableByColumnSQL(Tables.SCENES, "Name", name));      
        //    conn.Close();

        //    return result;
        //}

        //public Scene GetSceneByID(int id)
        //{
        //    conn.Open();
        //    Scene result = (Scene)ExecuteReturnSingle(GetFromTableByColumnSQL(Tables.SCENES, "Id", id.ToString()));
        //    conn.Close();

        //    return result;
        //}

        //public List<Scene> GetAllScenes()
        //{
        //    conn.Open();
        //    var result = ExecuteReturnMultiple(GetAllFromTableSQL(Tables.SCENES));
        //    conn.Close();

        //    return new List<Scene>(result.Cast<Scene>());
        //}

        //public void UpdateScene(Scene scene)
        //{
        //    conn.Open();

        //    string[] columns = new string[] { "Name" };
        //    string[] values = new string[] { scene.Name };
        //    Execute(GetUpdateSQL(Tables.SCENES, columns, values, scene.Id));



        //    conn.Close();
        //}

        //public List<Asset> GetAssets(int id)
        //{
        //    return null;
        //}
    }
}
