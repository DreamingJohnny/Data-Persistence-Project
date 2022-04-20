using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameUI : MonoBehaviour {

	[SerializeField] private TextMeshProUGUI nameText;
	[SerializeField] private TextMeshProUGUI highScore;
	[SerializeField] private Text score;

	void Start() {
		LoadPlayer();
	}

	void Update() {

	}

	private void LoadPlayer() {
		string path = Application.persistentDataPath + "/savefile.json";

		PlayerData playerData = new PlayerData();
		playerData = DataHandler.Instance.LoadPlayerData(path);

		nameText.text = playerData.name;
		highScore.text = playerData.highScore.ToString();
	}

	public void ExitGame() {

	}
}
