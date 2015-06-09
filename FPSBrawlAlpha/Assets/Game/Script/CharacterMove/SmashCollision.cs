using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Rigidbody))]
public class SmashCollision : MonoBehaviour {

	float frontAngle = 30f;
	float backAngle = 150f;
	new Rigidbody rigidbody;

	// Use this for initialization
	void Start () {
		rigidbody = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter(Collision collision)
	{
		Vector3 contactNormal = collision.contacts[0].normal;
		float collisionAngle = Vector3.Angle(rigidbody.velocity, contactNormal);
		bool thisIsDefeated = (Vector3.Dot(rigidbody.velocity + GetComponent<Collider>().GetComponent<Rigidbody>().velocity, contactNormal) < 0);

		if(collisionAngle < frontAngle){
			if(thisIsDefeated){

			}else{

			}
		}else if(backAngle < collisionAngle){
			if(thisIsDefeated){
				
			}else{
				
			}
		}else{
			if(thisIsDefeated){
				
			}else{
				
			}
		}
	}
}

interface IDefeatBehavior 
{
}

class DefeatBehavior : IDefeatBehavior
{
}