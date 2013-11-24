using UnityEngine;
using System.Collections;

public class BatteryScript : MonoBehaviour {

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Runner") {
			Debug.Log ("Something hit a Battery!");
			col.gameObject.GetComponent<RunnerScript>().batteryPower += 30;
			Destroy(gameObject);
		}
	}
}