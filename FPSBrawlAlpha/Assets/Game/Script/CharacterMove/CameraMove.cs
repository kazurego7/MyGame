using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	GameObject player = null;
	Vector3 vectorPlayerToCamera = new Vector3();
	float anglePlayerToCameralook = 0f;

	public float CameraSpeedToPlayerSpeed = 0.7f;
	public float longDistance = 10f;
	float sqrLongDistance;
	public float shortDistance = 3f;
	float sqrShortDistance;
	public float maxAngle = 30f;
	public float returnVelocity = 40f;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player").gameObject;
		sqrLongDistance = longDistance * longDistance;
		sqrShortDistance = shortDistance * shortDistance;
	}
	
	// Update is called once per frame
	void Update () {
		// カメラからプレイヤーへのベクトル
		vectorPlayerToCamera = this.transform.position - player.transform.position;
		// カメラとプレイヤーの角度
		anglePlayerToCameralook = Vector3.Angle(player.transform.rotation * Vector3.forward, -vectorPlayerToCamera);

		// カメラの速度をプレイヤーのCameraSpeedToPlayerSpeed倍に
		this.GetComponent<Rigidbody>().velocity = CameraSpeedToPlayerSpeed * player.GetComponent<Rigidbody>().velocity;


		// -------------------------------- カメラの移動 -----------------------------------------
		// もしプレイヤーがカメラから離れすぎたら
		if ( sqrLongDistance < vectorPlayerToCamera.sqrMagnitude ) {
			// プレイヤーとの距離を保つ
			this.transform.position = player.transform.position + vectorPlayerToCamera.normalized * longDistance;
		
		// もしプレイヤーがカメラに近付きすぎたら
		} else if ( sqrShortDistance > vectorPlayerToCamera.sqrMagnitude ) {
			//プレイヤーと一定の距離を保つ
			this.transform.position = player.transform.position + vectorPlayerToCamera.normalized * shortDistance;
		}

		//--------------- カメラの向き ----------------------
		this.transform.rotation = player.transform.rotation;

	}
}
