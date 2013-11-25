using UnityEngine;
using System.Collections;

public class LightstickBundleScript : MonoBehaviour {

	public int amount;

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Runner") {
			col.gameObject.GetComponent<RunnerScript>().lightSticks += amount;
			Destroy (gameObject);

		}
	}
}