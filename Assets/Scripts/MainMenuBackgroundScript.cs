using UnityEngine;
using System.Collections;

public class MainMenuBackgroundScript : MonoBehaviour {

	public int lightningChance;
	public float lightningFade;
	public float menuPosition;
	public GameObject menuLight;
	public AudioClip lightningSound;
	public GameObject logo;
	public float LogoX;
	public float LogoY;
	public float LogoZ;

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
		if (GUI.Button(new Rect(10, menuPosition, Screen.width / 3, 30), "Level_01"))
			Application.LoadLevel ("Level_01");

		if (GUI.Button(new Rect(10, menuPosition + 40, Screen.width / 3, 30), "Level_02"))
			Application.LoadLevel ("Level_02");

		if (GUI.Button(new Rect(10, menuPosition + 80, Screen.width / 3, 30), "Level_03"))
			Application.LoadLevel ("Level_03");
		
		if (GUI.Button(new Rect(10, menuPosition + 120, Screen.width / 3, 30), "Level_04"))
			Application.LoadLevel ("Level_04");
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Debug.Log ("Lol the game didn't quit");
		}
		if (menuLight.light.intensity > 0) {
			menuLight.light.intensity -= lightningFade * Time.deltaTime;
		}
		float LogoOffsetY = LogoY - Screen.height;
		logo.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(LogoX,LogoOffsetY,LogoZ));
	}
}