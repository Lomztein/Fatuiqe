using UnityEngine;
using System.Collections;

public class LightstickPickupScript : MonoBehaviour {

	float aliveTime = 1;

	// Use this for initialization
	void Update () {
		aliveTime -= 1 * Time.deltaTime;
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Runner" && aliveTime <= 0) {
			col.gameObject.GetComponent<RunnerScript>().lightSticks += 1;
			Destroy (gameObject);
		}
	}
}