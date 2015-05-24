using UnityEngine;
using System.Collections;

public class DamageApplyer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void DamageApply(ref int itsHitPoint, int damagedPoint) {
		itsHitPoint -= damagedPoint;
		if (itsHitPoint == 0) {
			Destroy(this.gameObject);
		}
	}
}
