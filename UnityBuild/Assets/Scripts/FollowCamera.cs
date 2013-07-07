using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	
	public GameObject target;
	public float zOffset = 10.0f;
	public float yOffset = 1.2f;
	
	void LateUpdate () {
		float newZ = target.transform.position.z + zOffset;
		float newY = target.transform.position.y + yOffset;
		float newX = target.transform.position.x;
		transform.position = new Vector3(newX, newY, newZ);
	}
}
