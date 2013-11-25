using UnityEngine;
using System.Collections;

public class BatteryBundleScript : MonoBehaviour {

	public int amount;
	
	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Runner") {
			col.gameObject.GetComponent<RunnerScript>().batteries += amount;
			Destroy (gameObject);
			
		}
	}
}