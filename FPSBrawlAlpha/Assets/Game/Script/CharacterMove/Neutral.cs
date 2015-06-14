using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerMoveC))]
[RequireComponent (typeof (Rigidbody))]

public class Neutral : MonoBehaviour {

	[SerializeField]
	private float _acceleration = 10f;
	public float Acceleration {
		get { return _acceleration; }
	}
	[SerializeField]
	private float _limitSpeed = 80f;
	public float LimitSpeed {
		get { return _limitSpeed; }
	}

	private new Rigidbody rigidbody;
	private PlayerMoveC playerMove;

	// Use this for initialization
	void Start () {
		this.rigidbody = GetComponent<Rigidbody>();
		playerMove = GetComponent<PlayerMoveC>();
	}

	public void TurnFront(){
		// キャラクターの視線方向へ,速度をdivideNumber分割
		this.rigidbody.velocity = Vector3.Slerp(this.rigidbody.velocity, transform.forward * this.rigidbody.velocity.magnitude, 1 / playerMove.divideNumber);
	}

	public void SlowlyAccelerate() {
		// ゆっくり加速
		if(this.rigidbody.velocity.magnitude < LimitSpeed) {
			this.rigidbody.velocity += this.rigidbody.velocity.normalized * Acceleration * Time.deltaTime;
		}
	}
}
