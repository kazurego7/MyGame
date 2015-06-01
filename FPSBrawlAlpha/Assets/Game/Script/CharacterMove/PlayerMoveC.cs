using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CharacterState))]
[RequireComponent (typeof (Booster))]
[RequireComponent (typeof (Neutral))]
public class PlayerMoveC : MonoBehaviour {

	public float maxSpeed = 80f;
	public float basicSpeed = 60f;
	public float divideNumber = 30f;

	Rigidbody rigidbody;
	CharacterState characterState;
	Booster booster;
	Neutral neutral;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody>();
		characterState = GetComponent<CharacterState> ();
		booster = GetComponent<Booster> ();
		neutral = GetComponent<Neutral>();
	}
	
	// Update is called once per frame
	void Update () {
		characterState.Change ();
		switch (characterState.Now) {
		case CharacterState.State.Neutral:
			neutral.BasicMove();
			break;
		case CharacterState.State.Dash:
			booster.Dash();
			break;
		case CharacterState.State.Scan:
			break;
		}
	}
}