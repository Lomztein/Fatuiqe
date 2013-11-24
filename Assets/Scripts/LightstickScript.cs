using UnityEngine;
using System.Collections;

public class LightstickScript : MonoBehaviour {
	
	public int time;
	public float fadeRate;

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
}