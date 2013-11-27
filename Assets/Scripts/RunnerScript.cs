using UnityEngine;
using System.Collections;

public class RunnerScript : MonoBehaviour {

	public bool torchEnabled;
	public float batteryDrain;
	public GameObject torch;
	public GameObject wideLight;
	public GameObject hunter;
	public float distanceToHunter;
	public int batteries;
	float maxBatteryPower = 100;
	public float batteryPower = 100;
	public int lightSticks;

	void Awake () {
		Invoke("Heartbeat",1f);
	}

	void Heartbeat () {
		Debug.Log("Heartbeat!");
		if (distanceToHunter < 50f) {
			Invoke("Heartbeat",Mathf.Max (distanceToHunter/25f,0.25f));
		}else{
			Invoke("Heartbeat",2f);
		}
	}

	void OnGUI () {
		GUI.Box (new Rect(10, 10, (Screen.width/(maxBatteryPower/batteryPower)) - 20,20),"Battery charge");
		GUI.Label (new Rect(10,Screen.height - 50, Screen.width, 20), "Lightsticks: "+lightSticks.ToString());
		GUI.Label (new Rect(10,Screen.height - 70, Screen.width, 20), "Batteries: "+batteries.ToString());
	}

	// Update is called once per frame
	void Update () {

		distanceToHunter = Vector3.Distance (transform.position,hunter.transform.position);

		if (batteryPower > 100) {
			batteryPower = 100;
		}

		//Toggle torch
		if (Input.GetButtonDown ("Toggle torch")) {
			if (torchEnabled) {
				torchEnabled = false;
			}else{
				torchEnabled = true;
			}
		}

		if (Input.GetButtonDown ("Fire3")) {
			if (batteries > 0) {
				batteryPower += 10;
				batteries --;
			}
		}

		//Control torch
		if (torchEnabled && batteryPower > 0) {
			torch.light.intensity = batteryPower/100;
			wideLight.light.intensity = Mathf.Max ((batteryPower/250)-0.5f,0);
			batteryPower -= batteryDrain * Time.deltaTime;
		}else{
			torch.light.intensity = 0;
			wideLight.light.intensity = 0;
			batteryPower += batteryDrain * 0.125f * Time.deltaTime;
		}
	}
}
