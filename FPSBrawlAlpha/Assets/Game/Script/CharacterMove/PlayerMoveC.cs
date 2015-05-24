using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerMoveC : MonoBehaviour {

	public float maxSpeed = 80f;
	public float basicSpeed = 60f;
	public float divideNumber = 30f;
	private Rigidbody rigidbody;
	// Use this for initialization
	void Start () {
		rigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		// もし,右または左ボタンがクリック,ホールドされていなければ
		if(!Input.GetMouseButton(1)&&!Input.GetMouseButton(0)) {
			// キャラクターの視線方向へ,速度を変更
			this.rigidbody.velocity = Vector3.Slerp(this.rigidbody.velocity, this.transform.forward * this.basicSpeed, 1 / divideNumber);
		}

	}
}