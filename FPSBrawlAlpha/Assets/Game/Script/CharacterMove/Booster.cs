using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (PlayerMoveC))]
public class Booster : MonoBehaviour {
	private new Rigidbody rigidbody;
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
