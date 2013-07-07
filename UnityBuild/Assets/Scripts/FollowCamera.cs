using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	
	public GameObject target;
	public float damping = 1;
	
	private Vector3 offset;
	
	void Start () {
		offset = target.transform.position - this.transform.position;
	}
	
	void LateUpdate () {
		float desiredAngle = target.transform.eulerAngles.y;
		//Quaternion rotation = Quaternion.Euler(0.0f, desiredAngle, 0.0f);
		gameObject.transform.position = new Vector3(target.transform.position.x, target.transform.position.y+5, target.transform.position.z+10);
		
		gameObject.transform.LookAt(target.transform);
	}
}
