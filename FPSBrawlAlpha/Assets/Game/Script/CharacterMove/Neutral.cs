using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerMoveC))]
[RequireComponent (typeof (Rigidbody))]

public class Neutral : MonoBehaviour {

	Rigidbody rigidbody;
	PlayerMoveC playerMove;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		playerMove = GetComponent<PlayerMoveC>();
	}

	public void BasicMove(){
		// キャラクターの視線方向へ,速度をdivideNumber分割
		rigidbody.velocity = Vector3.Slerp(rigidbody.velocity, transform.forward * playerMove.basicSpeed, 1 / playerMove.divideNumber);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
