using UnityEngine;
using System.Collections;


[RequireComponent (typeof (Rigidbody))]
public class SmashCollision : MonoBehaviour {

	float frontAngle = 30f;
	float backAngle = 150f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter(Collision collision)
	{
		Vector3 contactNormal = collision.contacts[0].normal;
		float collisionAngle = Vector3.Angle(this.GetComponent<Rigidbody>().velocity, contactNormal);
		bool thisIsDefeated = (Vector3.Dot(this.GetComponent<Rigidbody>().velocity + GetComponent<Collider>().GetComponent<Rigidbody>().velocity, contactNormal) < 0);

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