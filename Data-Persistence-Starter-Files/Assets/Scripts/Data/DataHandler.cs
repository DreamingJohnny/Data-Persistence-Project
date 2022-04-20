using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataHandler : MonoBehaviour {

	public static DataHandler Instance;

	private void Awake() {

		if (Instance != null) {
			Destroy(gameObject);
			return;
		}

		Instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void SaveData(string data) {
		File.WriteAllText(Application.persistentDataPath + "/savefile.json", data);

	}

	public PlayerData LoadPlayerData(string path) {
		if (File.Exists(path)) {
			string json = File.ReadAllText(path);
			PlayerData data = JsonUtility.FromJson<PlayerData>(json);
			return data;
		}

		return new PlayerData();
	}

	public int GetScore() {
		string path = Application.persistentDataPath + "/savefile.json";

		if(File.Exists(path)) {
			string json = File.ReadAllText(path);
			PlayerData data = JsonUtility.FromJson<PlayerData>(json);
			return data.highScore;
		}

		return 0;
	}
}
