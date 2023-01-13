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
    public static void AddPlayer()
    {
        string conn = "URI=file:" + Application.dataPath + "/Database.db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        try
        {
            dbconn.Open(); //Open connection to the database.
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error opening the database: " + e.Message);
            return;
        }
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT id, coins, keys, currentlevel, health, playertype" + "FROM player";
        string updateQuery = "UPDATE player SET coins, keys, currentlevel, health, playertype = " + PlayerVariablesAndItems.CoinCount + ", keys = " + PlayerVariablesAndItems.keyCount + " WHERE id = " + PlayerVariablesAndItems.ID;

        dbcmd.CommandText = sqlQuery;
        try
        {
            IDataReader reader = dbcmd.ExecuteReader();
            reader.Close();
            reader = null;
            dbcmd.Dispose();
            dbcmd = null;
            dbconn.Close();
            dbconn = null;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error executing the query: " + e.Message);
        }
        Debug.Log("Data added to the database successfully.");
    }

    void ReadDatabase()
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
