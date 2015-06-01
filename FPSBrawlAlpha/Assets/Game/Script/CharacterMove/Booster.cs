using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (PlayerMoveC))]
public class Booster : MonoBehaviour {
	public float dashSpeed = 60f;
	private bool isDone = true;
	private Rigidbody rigidbody;
	private PlayerMoveC playerMove;

    void Update()
    {
    }

	public void Dash()
	{
	}

	// Use this for initialization
	void Start () {
		playerMove = GetComponent<PlayerMoveC> ();
		rigidbody = GetComponent<Rigidbody> ();
	}
}
