using UnityEngine;
using System.Collections;

public class CharacterRotation : MonoBehaviour
{
	public float rotationSpeed = 100f; // 回転速度
	public Quaternion TurnRegularly(Vector3 rotationDirection)
	{
		return Quaternion.RotateTowards (Quaternion.LookRotation (this.GetComponent<Rigidbody>().velocity), Quaternion.LookRotation (rotationDirection), rotationSpeed * Time.deltaTime);
	}
}