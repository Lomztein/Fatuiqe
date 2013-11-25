using UnityEngine;
using System.Collections;

public class LightstickScript : MonoBehaviour {
	
	public int time;
	public float fadeRate;

	// Use this for initialization
	void Update () {
		light.intensity -= fadeRate * Time.deltaTime;
		if (light.intensity <= 0) {
			Destroy (gameObject);
		}
	}
}