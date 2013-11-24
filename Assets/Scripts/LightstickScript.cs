using UnityEngine;
using System.Collections;

public class LightstickScript : MonoBehaviour {
	
	public int time;
	public float fadeRate;
	float aliveTime = 120;

	// Use this for initialization
	void Start () {
		Invoke ("Destroy",time);
	}
	void Update () {
		light.intensity -= fadeRate * Time.deltaTime;
	}
	void Destroy () {
		Destroy (gameObject);
	}
/*	void OnTriggerEnter (Collider col) {
		if (aliveTime < 0) {
			if (col.gameObject.name == "Runner") {
				col.gameObject.GetComponent<RunnerScript>().lightSticks ++;
			}
		}
	}*/
}