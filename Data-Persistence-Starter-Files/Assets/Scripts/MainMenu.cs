using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	[SerializeField] private TMP_InputField nameField;

	void Start() {
		LoadName();
	}

	public void StartGame() {
		if(nameField.text != " ") SceneManager.LoadScene(1);
	}

	public void SaveName() {
		PlayerData data = new PlayerData();
		data.name = nameField.text;
		string json = JsonUtility.ToJson(data);

		DataHandler.Instance.SaveData(json);
	}

	public void LoadName() {
		string path = Application.persistentDataPath + "/savefile.json";

		PlayerData playerData = DataHandler.Instance.LoadPlayerData(path);

		nameField.text = playerData.name;
	}

}
