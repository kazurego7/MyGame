using UnityEngine;
using System.Collections;

public class BallMoveA : MonoBehaviour {
	public float basicMoveSpeed = 20f;
	// Use this for initialization
	void Start () {
		this.GetComponent<Rigidbody>().velocity = Vector3.forward * basicMoveSpeed;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
