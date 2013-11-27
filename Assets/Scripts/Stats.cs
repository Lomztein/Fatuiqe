using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {
	
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.LoadLevel("MainMenu");
		}
	}
}