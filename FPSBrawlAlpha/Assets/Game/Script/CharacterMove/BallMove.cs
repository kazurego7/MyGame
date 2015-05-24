using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour {

	float startTime = 0;
	public float interval = 5f;
	public float maxSpeed = 20f;
	public float accel = 20f;
	float curretSpeed = 0f;
	Quaternion dirQua = new Quaternion();
	Vector3 tmpVec = new Vector3();
	// Use this for initialization
	void Start () {
		tmpVec = Vector3.forward;
	}
	
	// Update is called once per frame
	void Update () {
		curretSpeed = GetComponent<Rigidbody>().velocity.magnitude;
		if (Time.time - startTime > interval) {
			dirQua = Quaternion.LookRotation(Random.insideUnitSphere);
			startTime = Time.time;
		}
		if (curretSpeed < maxSpeed) {
			GetComponent<Rigidbody>().velocity += dirQua * Vector3.forward * accel * Time.deltaTime * 0.5f;
		} else {
			GetComponent<Rigidbody>().velocity = dirQua * Vector3.forward * maxSpeed;
		}
		this.transform.rotation = Quaternion.FromToRotation(this.transform.position, this.GetComponent<Rigidbody>().velocity);
	}
}
