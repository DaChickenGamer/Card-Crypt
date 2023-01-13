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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
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

=======
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
>>>>>>> parent of ad692a5 (Almost Working Database)
=======
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
>>>>>>> parent of ad692a5 (Almost Working Database)
=======
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
>>>>>>> parent of ad692a5 (Almost Working Database)
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
<<<<<<< HEAD
<<<<<<< HEAD
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
=======
>>>>>>> parent of ad692a5 (Almost Working Database)
=======
>>>>>>> parent of ad692a5 (Almost Working Database)
    }
}
