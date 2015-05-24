using UnityEngine;
using System.Collections;

public class CharacterInput : MonoBehaviour {
	/// <summary>
	/// キー操作の内のいくつかを,移動データに変える
	/// </summary>
	// Use this for initialization
	void Start () {
	
	}

	Vector3 putDirection;
	Vector3 holdDirection;

	// 方向の初期化
	public void initializeDirections()
	{
		putDirection = holdDirection = Vector3.zero;
	}

	// InputをAction(移動やその他のアクション)
	public void ChangeInputToAction()
	{
		ChangeMoveKeyToDirection();
		ChangeDecelKeyToDirection();
	}

	// MoveKey(WASD)を方向に変える
	public void ChangeMoveKeyToDirection()
	{
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
	}

	// DecelKey(減速キー:Shift)を方向に変える
	public void ChangeDecelKeyToDirection()
	{
		// もし最少速度よりも小さければ減速はしない
		if (this.GetComponent<Rigidbody>().velocity.magnitude > 1/*smallRadius*/) {
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
	}

}
