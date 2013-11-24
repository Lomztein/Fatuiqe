using UnityEngine;
using System.Collections;

public class RunnerScript : MonoBehaviour {

	public bool torchEnabled;
	public float batteryDrain;
	public GameObject torch;
	float maxBatteryPower = 100;
	public float batteryPower = 100;
	public int lightSticks;

	void OnGUI () {
		GUI.Box (new Rect(10, Screen.height - 30, (Screen.width/(maxBatteryPower/batteryPower)) - 20, 20),"Battery charge " + Mathf.Round(batteryPower) + "%");
	}

	// Use this for initialization
	public void chargeBattery () {
		if (batteryPower > 70) {
			batteryPower = 100;
		}else{
			batteryPower += 30;
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (batteryPower > 100) {
			batteryPower = 100;
		}

		//Toggle torch
		if (Input.GetButtonDown ("Fire1")) {
			if (torchEnabled) {
				torchEnabled = false;
			}else{
				torchEnabled = true;
			}
		}
		//Control torch
		if (torchEnabled && batteryPower > 0) {
			torch.light.intensity = batteryPower/100;
			batteryPower -= batteryDrain * Time.deltaTime;
		}else{
			torch.light.intensity = 0;
			batteryPower += batteryDrain * 0.25f * Time.deltaTime;
		}
	}
}
