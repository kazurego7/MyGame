using UnityEngine;
using System.Collections;

public class CharacterVelocityDirectioner : MonoBehaviour {
	public GameObject Character = null;
	public GameObject Child = null;
	public Vector3 basicScale = new Vector3();

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		Child.transform.localScale = basicScale + new Vector3(0,0, Vector3.Magnitude(Character.GetComponent<Rigidbody>().velocity) * 0.01f);
		this.transform.rotation = Quaternion.LookRotation(Character.gameObject.GetComponent<Rigidbody>().velocity);
	}
}
