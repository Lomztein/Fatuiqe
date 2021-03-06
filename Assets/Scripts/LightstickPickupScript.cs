﻿using UnityEngine;
using System.Collections;

public class LightstickPickupScript : MonoBehaviour {

	float aliveTime = 1;

	void Update () {
		aliveTime -= 1 * Time.deltaTime;
	}

	void OnTriggerEnter (Collider col) {
		if (col.gameObject.name == "Runner" && aliveTime <= 0) {
			Destroy (gameObject);
			if (Mathf.Round(Random.value*10) != 1) {
				col.gameObject.GetComponent<RunnerScript>().lightSticks += 1;
			}
		}
	}
}