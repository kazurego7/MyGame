using UnityEngine;
using System.Collections;

public class PlayerMove : MonoBehaviour {

	public GameObject bullet = null;	// 弾
	
	public float basicMoveSpeed = 20.0f;		// プレイヤーの基本的な速さ

	public AnimationCurve DashCurve = null;	// 速さの変化カーブ
	float dashStartTime = -10.0f;				// ダッシュが始まる時刻
	Vector3 dashStartDirection = Vector3.zero;	// ダッシュ開始時のベクトル


	Vector3 center = new Vector3(Screen.width/2, Screen.height/2, 0);
	RaycastHit hit;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		//--------------- キー判定 -----------------------------
		if( Input.GetKeyDown(KeyCode.W) ){
			dashStartTime = Time.time;
			dashStartDirection = this.transform.forward;
		}
		if( Input.GetKeyDown(KeyCode.S) ) {
			dashStartTime = Time.time;
			dashStartDirection = -this.transform.forward;
		}
		if( Input.GetKeyDown(KeyCode.A) ) {
			dashStartTime = Time.time;
			dashStartDirection = -this.transform.right;
		}
		if( Input.GetKeyDown(KeyCode.D) ) {
			dashStartTime = Time.time;
			dashStartDirection = this.transform.right;
		}

		if( Input.GetMouseButtonDown(0) && Physics.Raycast( Camera.main.ScreenPointToRay(center), out hit, 100) ) {
			Debug.Log("Slash!");
		}
		if( Input.GetMouseButtonDown(1) ) {
			Debug.Log("Bamg!");
			Instantiate(bullet, transform.position + transform.rotation * Vector3.forward * 2, transform.rotation);
		}
		//------------ ダッシュの実行 ---------------------------
		// 経過時間
		float passedDashTime = Time.time - dashStartTime;
		if( passedDashTime <= 1.0f) {
			GetComponent<Rigidbody>().velocity = basicMoveSpeed * DashCurve.Evaluate(passedDashTime) * dashStartDirection;
		}

	}
}
