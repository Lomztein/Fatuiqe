using UnityEngine;
using System.Collections;

public class RunnerScript : MonoBehaviour {

	public bool torchEnabled;
	public float batteryDrain;
	public GameObject hunter;
	public float distanceToHunter;
	public int batteries;
	public AudioClip heatbeatSound;
	float maxBatteryPower = 100;
	public float batteryPower = 100;
	public int lightSticks;
	public float maxLightIntensity;
	public GameObject futureEquip;
	public Vector3 equipmentPosition;
	public GameObject runnerCamera;
	public GameObject currentEquip = null;
	public float useDistance;

	void Awake () {
		Invoke("Heartbeat",1f);
		if (futureEquip == null) {
			Debug.Log ("No equipment detected");
		}else{
			SpawnEquipment ();
		}
	}

	void SpawnEquipment () {
		currentEquip = (GameObject)Instantiate(futureEquip,equipmentPosition,transform.rotation);
		currentEquip.transform.parent = runnerCamera.transform;
		currentEquip.transform.position = runnerCamera.transform.position + equipmentPosition;
		futureEquip = null;
	}

	void Heartbeat () {
		audio.PlayOneShot(heatbeatSound);
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
		GUI.Label (new Rect(10,Screen.height - 90, Screen.width, 20), "Equipment: "+currentEquip.ToString());
	}

	// Update is called once per frame
	void Update () {

		if (currentEquip) {
			currentEquip.transform.position = runnerCamera.transform.position + equipmentPosition;
			distanceToHunter = Vector3.Distance (transform.position,hunter.transform.position);
		}

		if (futureEquip) {
			if (currentEquip) {
				Destroy(currentEquip.gameObject);
			}
			SpawnEquipment();
		}

		if (batteryPower > 100) {
			batteryPower = 100;
		}

		if (batteryPower <= 0) {
			torchEnabled = false;
			batteryPower = 0;
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

		if (Input.GetButtonDown ("Use")) {
			if (Physics.Raycast(runnerCamera.transform.position,runnerCamera.transform.forward,useDistance)) {
				Debug.Log("Hit something!");
			}
		}
	}
}