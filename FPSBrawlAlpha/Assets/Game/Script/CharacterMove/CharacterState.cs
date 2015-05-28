using UnityEngine;
using System.Collections;

public class CharacterState : MonoBehaviour {
	public enum State {Neutral,Dash,Scan}
	// 現在の状態
	public State Now { get; private set; }

	// キャラクターの状態遷移
	public void Change(){
		switch (Now) {
		case State.Neutral:
			if(Input.GetMouseButton(0)){
				Now = State.Dash;
			} else if (Input.GetMouseButton(2)){
				Now = State.Scan;
			}
			break;
		case State.Dash:
			if(Input.GetMouseButtonUp(0)){
				Now = State.Neutral;
			}else if(Input.GetMouseButton(2)){
				Now = State.Scan;
			}
			break;
		case State.Scan:
			if(Input.GetMouseButtonUp(2)){
				Now = State.Neutral;
			}
			break;
		}
	}

	// Use this for initialization
	void Start () {
		Now = State.Neutral;
	}
	// Update is called once per frame
	void Update () {
	
	}
}
