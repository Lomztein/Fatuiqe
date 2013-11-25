using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject bullet;
	public GameObject parantPlayerObject;
	public float bulletSpeed;

	private RunnerScript runnerScript;

	void Awake () {
		runnerScript = parantPlayerObject.GetComponent<RunnerScript>();
	}

	void Update () {
		if (Input.GetButtonDown ("Fire2") && runnerScript.lightSticks > 0) {
			GameObject lastBullet = (GameObject)Instantiate(bullet,transform.position,transform.rotation);
			lastBullet.rigidbody.AddForce (transform.forward * bulletSpeed,ForceMode.Impulse);
			runnerScript.lightSticks --;
		}
	}
}