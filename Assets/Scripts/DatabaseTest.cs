using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

public class DatabaseTest : MonoBehaviour
{
    private PlayerVariablesAndItems player;
    void Start()
    {
        ReadDatabase();
    }

    public void SaveGame()
    {
        AddPlayer();
    }

    void ReadDatabase()
    {
            string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database.
            IDbConnection dbconn;
            dbconn = (IDbConnection)new SqliteConnection(conn);
            dbconn.Open(); //Open connection to the database.
            IDbCommand dbcmd = dbconn.CreateCommand();
            string sqlQuery = "SELECT username, password " + "FROM user";
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

    public static void AddPlayer()
    {
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT coins, keys, currentlevel, health, playertype" + "FROM player";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            PlayerVariablesAndItems.ID = reader.GetInt32(0);
            PlayerVariablesAndItems.CoinCount = reader.GetInt32(1);
            PlayerVariablesAndItems.keyCount = reader.GetInt32(2);
            ChangeScene.PlayerScene = reader.GetInt32(3);
            PlayerVariablesAndItems.healthValue = reader.GetInt32(4);
            PlayerSpawner.playerType = reader.GetInt32(5);
        }
        reader.Close();
        reader = null;
        dbconn.Close();
        dbconn = null;
    }
}
