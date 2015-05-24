using UnityEngine;
using System.Collections;

public class HitSelecter: MonoBehaviour {

	public GameObject next = null;
	public float duration = 0;	// フレームで記入
	private float timer = 0f;

	public void Attack()
	{

	}
	public void Release()
	{

	}

	// インスタンス化された瞬間に非アクティブになる
	void Awake() {
		this.gameObject.SetActive (false);
	}

	// このゲームオブジェクトはHitSelecter及びFirstNonHitterからのみアクティベートされることを想定している
	void OnEnable() {

	}

	// Use this for initialization
	void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (duration * Time.deltaTime < timer){
			timer = 0f;
			if(next != null) {
				next.SetActive(true);
			}
			this.gameObject.SetActive(false);
		}
	}
}