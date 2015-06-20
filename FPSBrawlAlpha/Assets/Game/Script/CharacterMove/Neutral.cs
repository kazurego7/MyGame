using UnityEngine;
using System.Collections;

[RequireComponent (typeof (PlayerMoveC))]
[RequireComponent (typeof (Rigidbody))]

public class Neutral : MonoBehaviour {

	// 通常の速度
	[SerializeField]
	private float _basicSpeed = 40f;
	public float BasicSpeed {
		get { return _basicSpeed; }
	}

	// ゆっくりと加速する際の加速度
	[SerializeField]
	private float _acceleration = 10f;
	public float Acceleration {
		get { return _acceleration; }
	}

	// ゆっくりと加速する限界の速さ
	[SerializeField]
	private float _limitSpeed = 80f;
	public float LimitSpeed {
		get { return _limitSpeed; }
	}

	// キャラクターが回転して減速しない限界の角周波数
	[SerializeField]
	private float _limitAngularFrequency = 60f;
	public float LimitAngularFrequency {
		get { return _limitAngularFrequency; }
	}

	// 視線と速度の差だけ回転するとき,回転分を何分割するか
	[SerializeField]
	private float _slerpDividingNum = 80f;
	public float SlerpDividingNum {
		get { return _slerpDividingNum; }
	}

	// プレイヤーが前フレームで向いていた方向
	private Vector3[] _looks = {Vector3.zero, Vector3.zero};
	public Vector3 PreLook {
		get {
			return _looks[1];
		}
		set {
			_looks[1] = _looks[0];
			_looks[0] = value;
		}
	}

	private new Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		this.rigidbody = GetComponent<Rigidbody>();
	}

	public void TurnFront(){
		// キャラクターの視線方向へ,速度をdivideNumber分割
		this.rigidbody.velocity = Vector3.Slerp(this.rigidbody.velocity, transform.forward * this.rigidbody.velocity.magnitude, 1 / SlerpDividingNum);
	}

	public void SlowlyAccelerate() {
		// ゆっくり加速
		if(this.rigidbody.velocity.magnitude < LimitSpeed) {
			this.rigidbody.velocity += this.rigidbody.velocity.normalized * Acceleration * Time.deltaTime;
		}
	}

	public void DeceelerateByRot() {
		// 回転による減速
		if(Vector3.Angle(PreLook, this.transform.forward) > LimitAngularFrequency) {
			this.rigidbody.velocity = this.rigidbody.velocity.normalized * BasicSpeed;
		}
	}
}
