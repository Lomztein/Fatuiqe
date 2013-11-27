using UnityEngine;
using System.Collections;

public class MainMenuBackgroundScript : MonoBehaviour {

	public int lightningChance;
	public float lightningLength;
	public float menuPosition;

	void FixedUpdate () {
		if (Mathf.Round(Random.value*lightningChance) == 1) {
			if (renderer.material.color != Color.white) {
				renderer.material.color = Color.white;
			}
		}
	}

	void OnGUI() {
		if (GUI.Button(new Rect(10, menuPosition, Screen.width -20, 30), "Level_01"))
			Application.LoadLevel ("Leve0_01");

		if (GUI.Button(new Rect(10, menuPosition + 40, Screen.width -20, 30), "Level_02"))
			Application.LoadLevel ("Level_02");

		if (GUI.Button(new Rect(10, menuPosition + 80, Screen.width -20, 30), "Level_03"))
			Application.LoadLevel ("Level_03");
		
		if (GUI.Button(new Rect(10, menuPosition + 120, Screen.width -20, 30), "Level_04"))
			Application.LoadLevel ("Level_04");
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Debug.Log ("Lol the game didn't quite");
		}
	}
}