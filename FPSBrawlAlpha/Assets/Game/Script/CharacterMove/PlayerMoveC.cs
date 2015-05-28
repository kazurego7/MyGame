using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CharacterState))]
[RequireComponent (typeof (Dasher))]
public class PlayerMoveC : MonoBehaviour {

	public float maxSpeed = 80f;
	public float basicSpeed = 60f;
	public float divideNumber = 30f;

	Rigidbody rigidbody;
	CharacterState characterState;
	Dasher dasher;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		characterState = GetComponent<CharacterState> ();
		dasher = GetComponent<Dasher> ();
	}
	
	// Update is called once per frame
	void Update () {
		characterState.Change ();
		switch (characterState.Now) {
		case CharacterState.State.Neutral:
			break;
		case CharacterState.State.Dash:
			dasher.Dash();
			break;
		case CharacterState.State.Scan:
			break;
		}
	}
}