using UnityEngine;
using System.Collections;

public class LightstickScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Invoke ("Burnout",30);
	}
	
	// Update is called once per frame
	void Burnout () {
		Destroy (light);
		Invoke ("Die",60);
	}

	void Die () {
		Destroy (gameObject);
	}
}