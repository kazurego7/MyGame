using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class Dasher : MonoBehaviour {
	public float dashSpeed = 60f;
	private bool isDone = true;
	private Rigidbody rigidbody;

	public void Initialize(Rigidbody rigidbody)
	{
		this.rigidbody = rigidbody;
	}
	public void Do()
	{
		// もし,左ボタンが押されれば
		if(Input.GetMouseButtonDown(0)){
			isDone = false;
		}
		// もし,左ボタンが離されれば
		if(Input.GetMouseButtonUp(0) && !isDone) {
			// ダッシュ
			this.rigidbody.velocity += this.transform.forward * dashSpeed;
			isDone = true;
		}
	}

	// Use this for initialization
	void Start () {+
	
	}
}
