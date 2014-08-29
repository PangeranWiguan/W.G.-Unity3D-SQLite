using UnityEngine;
using System.Collections;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class DBAccess : MonoBehaviour {

	// Use this for initialization
	void Start () {

		string connectionString = "URI=file:" +Application.dataPath + "/GameMaster"; //Path to database.
		IDbConnection dbcon;
		dbcon = (IDbConnection) new SqliteConnection(connectionString);

		dbcon.Open(); //Open connection to the database.

		IDbCommand dbcmd = dbcon.CreateCommand();

		string sql = "SELECT firstname, lastname " + "FROM addressbook";

		dbcmd.CommandText = sql;

		IDataReader reader = dbcmd.ExecuteReader();

		while(reader.Read()) {
			string FirstName = reader.GetString (0);
			string LastName = reader.GetString (1);
			Console.WriteLine("Name: " +
			                  FirstName + " " + LastName);
			Debug.Log (FirstName + LastName);
		}

		// clean up
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbcon.Close();
		dbcon = null;
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	void OnGUI () {



		string connectionString = "URI=file:" +Application.dataPath + "/GameMaster"; //Path to database.
		IDbConnection dbcon;
		dbcon = (IDbConnection) new SqliteConnection(connectionString);
		
		dbcon.Open(); //Open connection to the database.
		
		IDbCommand dbcmd = dbcon.CreateCommand();
		
		string sql = "SELECT firstname FROM addressbook WHERE rowid=1";
		
		dbcmd.CommandText = sql;
		
		IDataReader reader = dbcmd.ExecuteReader();
		
		while(reader.Read()) {
			string FirstName = reader.GetString (0);
			//string LastName = reader.GetString (1);
			//Console.WriteLine("Name: " +
			                  //FirstName + " " + LastName);
			//Debug.Log (FirstName + LastName);

			GUI.Box (new Rect (Screen.width - 270, Screen.height - 55, 260, 30), "Copyright "+FirstName+" 2014");
		}
		
		// clean up
		reader.Close();
		reader = null;
		dbcmd.Dispose();
		dbcmd = null;
		dbcon.Close();
		dbcon = null;

	}
}
