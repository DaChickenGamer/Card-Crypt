using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseTest : MonoBehaviour
{
    private void Start()
    {
       ReadDatabase();
    }

    void ReadDatabase()
    {
            string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT username, password " + "FROM user";
            //sqlQuery = "SELECT coins, health, items " + "FROM player";
        dbcmd.CommandText = sqlQuery;
            IDataReader reader = dbcmd.ExecuteReader();
            while(reader.Read())
            {
                //int coins = reader.GetInt32(0);
                //int health = reader.GetInt32(2);
                //int items = reader.GetInt32(3);
                string username = reader.GetString(0);
                string password = reader.GetString(1);

            Debug.Log("Username: " + username + "  Password: " + password);
            }
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
    }
}
