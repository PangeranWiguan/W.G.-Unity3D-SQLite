using UnityEngine;
using System;
using Mono.Data.Sqlite; //Newer than Mono.Data.Sqliteclient and only support SQLite 3.

public class dbController : MonoBehaviour {
	
	protected SqliteConnection dbconn;

	void Awake () {
		if (Application.platform == RuntimePlatform.IPhonePlayer) {
			dbconn = new SqliteConnection("URI=file:" +Application.dataPath + "/../GameMaster");
		} else {
			dbconn = new SqliteConnection("URI=file:" +Application.dataPath + "/GameMaster");	
		}

		Debug.Log("URI=file:" +Application.dataPath + "/GameMaster");
		dbconn.Open();
		
		try {
			SqliteCommand cmd = new SqliteCommand("SELECT firstname FROM adressbook", dbconn);
			SqliteDataReader reader = cmd.ExecuteReader();
			
			if (reader.HasRows) {
				while(reader.Read()) {
					string FirstName = reader.GetString (0);
					string LastName = reader.GetString (1);
					
					Debug.Log ( FirstName + LastName );
				}
			}
			
			reader.Close();
			reader = null;
		} catch {
			Debug.Log("Error reading DB");
		}
		
		//cmd.Dispose();
		//cmd = null;
		dbconn.Close();
		dbconn = null;
		
		
	}
	
}