using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject bullet;
	public float bulletSpeed;

	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown ("Fire2")) {
			GameObject lastBullet = (GameObject)Instantiate(bullet,transform.position,transform.rotation);
			lastBullet.rigidbody.AddForce (transform.forward * bulletSpeed,ForceMode.Impulse);
		}
	}
}
