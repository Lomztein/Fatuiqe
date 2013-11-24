using UnityEngine;
using System.Collections;

public class BatteryScript : MonoBehaviour {

	public float charge;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Runner") {
			col.gameObject.GetComponent<RunnerScript>().batteryPower += charge;
			Destroy(gameObject);
		}
	}
}