using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMoveA : MonoBehaviour
{

	public float HitPoint = 0f;
	public GameObject bullet = null;	// 弾
	GameObject tmpBullet = null;
	public GameObject slash = null;		// 斬撃
	public GameObject slashEnd = null;
	GameObject tmpSlash = null;
	public float basicMoveSpeed = 20.0f;		// プレイヤーの基本的な速さ
	Vector3 direction = new Vector3 ();
	Vector3 putDirection = new Vector3 ();
	Vector3 holdDirection = new Vector3 ();
	Quaternion nextRotation = new Quaternion ();

	public float rotateSpeed = 100f;	// 回転速度
	public float largeAngle = 135f;		// 
	public float smallAngle = 45f;		// 
	public float delayForDash = 5f;
	public float initialSpeed = 20f;	// 初速
	public float smallRadius = 5f;		// 準与初速半径
	public float overspeedRadius = 70f;	// 
	public float acceleration = 100f;	// 加速度
	public float deceleration = 100f;	// 減速度
	public float naturalDeceleration = 20f;	// 自然減速度
	public GameObject naturalBaseObject = null;	// 系の原点となるオブジェクト

	Vector3 center = new Vector3 (Screen.width / 2, Screen.height / 2, 0);
	RaycastHit hit;
	
	// Use this for initialization
	void Start ()
	{
	}
	
	// Update is called once per frame
	void Update ()
	{
		//--------------- キー判定 -----------------------------
		//キーごとに別の機能を割り当てるかもしれない
		putDirection = holdDirection = Vector3.zero;
		if (Input.GetKeyDown (KeyCode.W)) {
			putDirection += this.transform.forward;
		} else if (Input.GetKey (KeyCode.W)) {
			holdDirection += this.transform.forward;
		}
		if (Input.GetKeyDown (KeyCode.S)) {
			putDirection += -this.transform.forward;
		} else if (Input.GetKey (KeyCode.S)) {
			holdDirection += -this.transform.forward;
		}
		if (Input.GetKeyDown (KeyCode.A)) {
			putDirection += -this.transform.right;
		} else if (Input.GetKey (KeyCode.A)) {
			holdDirection += -this.transform.right;
		}
		if (Input.GetKeyDown (KeyCode.D)) {
			putDirection += this.transform.right;
		} else if (Input.GetKey (KeyCode.D)) {
			holdDirection += this.transform.right;
		}

		bool accelFlag = true;
		// もし最少速度よりも小さければ減速はしない
		if (this.GetComponent<Rigidbody>().velocity.magnitude > smallRadius) {
			if (holdDirection == Vector3.zero) {
				if (Input.GetKeyDown (KeyCode.LeftShift)) {
				} else if (Input.GetKey (KeyCode.LeftShift)) {
					putDirection = Vector3.zero;
					holdDirection = -this.GetComponent<Rigidbody>().velocity;
				}
			} else {
				if (Input.GetKeyDown (KeyCode.LeftShift)) {
					putDirection = -this.GetComponent<Rigidbody>().velocity;
					holdDirection = Vector3.zero;
				} else if (Input.GetKey (KeyCode.LeftShift)) {
					putDirection = Vector3.zero;
					holdDirection = -this.GetComponent<Rigidbody>().velocity;
				}
			}
		}

		direction = holdDirection + putDirection;

		if (Input.GetMouseButtonDown (0) && Physics.Raycast (Camera.main.ScreenPointToRay (center), out hit, 100)) {
			Debug.Log ("Slash!");
			slash.SetActive (true);
		}
		if (Input.GetMouseButtonDown (1)) {
			Debug.Log ("Bamg!");
			tmpBullet = (GameObject)Instantiate (bullet, transform.position + transform.rotation * Vector3.forward * 4, transform.rotation);
			tmpBullet.GetComponent<Rigidbody>().velocity += this.GetComponent<Rigidbody>().velocity;
		}
		//------------ ベクトルの回転 ---------------------------
		// 経過時間
		float currentSpeed = this.GetComponent<Rigidbody>().velocity.magnitude;
		Vector3 currentDirection = this.GetComponent<Rigidbody>().velocity / currentSpeed;
		nextRotation = Quaternion.identity;
		if (direction != Vector3.zero) {	// ゼロベクトルでは角度を求められない！
			float angulerDefference = Vector3.Angle (direction, this.GetComponent<Rigidbody>().velocity);
			if (angulerDefference >= largeAngle) {	// 減速域
				nextRotation = Quaternion.RotateTowards (Quaternion.LookRotation (this.GetComponent<Rigidbody>().velocity), Quaternion.LookRotation (-direction), rotateSpeed * Time.deltaTime);
				this.GetComponent<Rigidbody>().velocity = nextRotation * Vector3.forward * currentSpeed - this.GetComponent<Rigidbody>().velocity.normalized * deceleration * Time.deltaTime;
			} else if (angulerDefference <= smallAngle) {	// 加速域
				nextRotation = Quaternion.RotateTowards (Quaternion.LookRotation (this.GetComponent<Rigidbody>().velocity), Quaternion.LookRotation (direction), rotateSpeed * Time.deltaTime);
				this.GetComponent<Rigidbody>().velocity = nextRotation * Vector3.forward * currentSpeed;
				if (currentSpeed < basicMoveSpeed) {	// 加速域での最大速度以下なら加速
					this.GetComponent<Rigidbody>().velocity += this.GetComponent<Rigidbody>().velocity.normalized * acceleration * Time.deltaTime;
				} else {	// 加速域での最大速度以上なら最大速度に固定
					this.GetComponent<Rigidbody>().velocity = nextRotation * Vector3.forward * basicMoveSpeed;
				}
			} else if (this.GetComponent<Rigidbody>().velocity != Vector3.zero) { // 回転域
				nextRotation = Quaternion.RotateTowards (Quaternion.LookRotation (this.GetComponent<Rigidbody>().velocity), Quaternion.LookRotation (direction), rotateSpeed * Time.deltaTime);
				this.GetComponent<Rigidbody>().velocity = nextRotation * Vector3.forward * currentSpeed;
			}

			if (currentSpeed <= smallRadius) {	// 与初速域
				this.GetComponent<Rigidbody>().velocity = Quaternion.LookRotation (direction) * Vector3.forward * initialSpeed;
			} else if (currentSpeed <= (initialSpeed + acceleration * delayForDash * Time.deltaTime)) {	// 準与初速域
				// ダッシュしてからdelayForDashのフレームだけ方向転換の猶予
				if (putDirection != Vector3.zero) {
					this.GetComponent<Rigidbody>().velocity = Quaternion.LookRotation (putDirection) * Vector3.forward * initialSpeed;
				}
			}

		} else {	// 自然減速
			if (naturalBaseObject == null) {

			} else if (naturalBaseObject == this.gameObject) {
				if (currentSpeed > 0.1f) {
					this.GetComponent<Rigidbody>().velocity -= this.GetComponent<Rigidbody>().velocity.normalized * naturalDeceleration * Time.deltaTime;
				}
			} else if (false) { // naturalBaseObject の速度に近くなければそれに自身の速度を時間に対して線形変換していく
			}
		}

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.GetComponent<Rigidbody>() != null) {
			Vector3 toOtherFromThis = other.transform.position - this.transform.position;
			// ぶつかったか、ぶつけられたか /正ならぶつかった・負ならぶつけられた
			var crashingSpeed = Vector3.Dot ((other.GetComponent<Rigidbody>().velocity + this.GetComponent<Rigidbody>().velocity), toOtherFromThis);
			// ぶつかった
			if (crashingSpeed > 0) {
				Debug.Log ("Clashing");
				// ぶつけられた
			} else if (crashingSpeed < 0) {
				Debug.Log ("Clashed");
				// おなじスピードでぶつかった
			} else {
				Debug.Log ("EachOtherClashed");
			}
		}
	}
}
