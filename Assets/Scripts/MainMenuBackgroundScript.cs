using UnityEngine;
using System.Collections;

public class MainMenuBackgroundScript : MonoBehaviour {

	public int lightningChance;
	public float lightningFade;
	public float menuPosition;
	public GameObject menuLight;
	public AudioClip lightningSound;
	public Texture logo;

	void FixedUpdate () {
		if (Mathf.Round(Random.value*lightningChance) == 1) {
			if (menuLight.light.intensity == 0) {
				audio.PlayOneShot(lightningSound);
				Invoke("LightningFlash",0.5f);
			}
		}
	}

	void LightningFlash () {
		menuLight.light.intensity = 1;
	}

	void OnGUI() {
		GUI.DrawTexture(new Rect(5, -135, 400, 400), logo, ScaleMode.ScaleToFit, true, 0);
		if (GUI.Button(new Rect(10, menuPosition, 135*3, 30), "Level_01"))
			Application.LoadLevel ("Level_01");

		if (GUI.Button(new Rect(10, menuPosition + 40, 135*3, 30), "Level_02"))
			Application.LoadLevel ("Level_02");

		if (GUI.Button(new Rect(10, menuPosition + 80, 135*3, 30), "Level_03 (DOESN'T EXISTS)"))
			Application.LoadLevel ("Level_03");
		
		if (GUI.Button(new Rect(10, menuPosition + 120, 135*3, 30), "Level_04 (DOESN'T EXISTS)"))
			Application.LoadLevel ("Level_04");

		if (GUI.Button(new Rect(10, menuPosition + 160, 135*3, 30), "Quit"))
			Application.Quit ();
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
		if (menuLight.light.intensity > 0) {
			menuLight.light.intensity -= lightningFade * Time.deltaTime;
		}
	}
}