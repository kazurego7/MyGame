using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (PlayerMoveC))]
public class Dasher : MonoBehaviour {
	public float dashSpeed = 60f;
	private bool isDone = true;
	private new Rigidbody rigidbody;
	private PlayerMoveC playerMove;

    void Update()
    {
    }

	public void Dash()
	{
		// キャラクターの視線方向へ,速度をdivideNumber分割
		rigidbody.velocity = Vector3.Slerp(rigidbody.velocity, transform.forward * playerMove.basicSpeed, 1 / playerMove.divideNumber);
	}

	// Use this for initialization
	void Start () {
		playerMove = GetComponent<PlayerMoveC> ();
		rigidbody = GetComponent<Rigidbody> ();
	}
}
