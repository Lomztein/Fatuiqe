using UnityEngine;
using System.Collections;

public class FPSController : MonoBehaviour {

	public float health;
	public float maxHealth;
	public float maxSpeed;
	public float sensitivity;
	public float ViewRangeY;
	public float jumpVelocity;
	float currentRotationV = 0;
	float speedY;
	CharacterController charController;


	// Use this for initialization
	void Start () {
		Screen.lockCursor = true;
		charController = GetComponent<CharacterController>();
	}

	void OnGUI () {
		GUI.Box (new Rect(10, Screen.height - 30, (Screen.width/(maxHealth/health)) - 20, 20),"Health");
	}
	
	// Update is called once per frame
	void Update () {

		//Rotation
		float rotationX = Input.GetAxis ("Mouse X") * sensitivity;
		transform.Rotate (0, rotationX, 0);

		currentRotationV -= Input.GetAxis ("Mouse Y") * sensitivity;
		currentRotationV = Mathf.Clamp(currentRotationV,-ViewRangeY,ViewRangeY);
		Camera.main.transform.localRotation = Quaternion.Euler(currentRotationV, 0 ,0);
		//Yes, its slightly confusing

		//Movement

		float forwardSpeed = Input.GetAxis ("Walk") * maxSpeed;
		float sidewaysSpeed = Input.GetAxis ("Strafe") * maxSpeed;

		speedY += Physics.gravity.y * Time.deltaTime;

		if(Input.GetButtonDown ("Jump") && charController.isGrounded) {
			speedY = jumpVelocity;
		}

		Vector3 speed = new Vector3 ( sidewaysSpeed, speedY, forwardSpeed);

		speed = transform.rotation * speed;

		charController.Move(speed * Time.deltaTime);

	}
}
