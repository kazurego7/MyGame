using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int speed = 50;
	public int damage = 1;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody>().velocity += transform.forward.normalized * speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider != null) {
			collider.gameObject.SendMessage("ApplyDamage", damage, SendMessageOptions.DontRequireReceiver);
		}
		Destroy(this.gameObject);
	}
}
