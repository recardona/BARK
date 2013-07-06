using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterController))]

public class BARKController : MonoBehaviour 
{
	private CharacterController controller;
	private Vector3 directionVector = Vector3.zero;
	
	public float moveSpeed = 3.0f;
	public float pushPower = 2.0f;
	
	void Start() {
		controller = GetComponent<CharacterController>();
		
		if(!controller) {
			Debug.LogError("BARKController.Start()" + this.name + "has no CharacterController attached.");
		}
	}
	
	void Update() {
		
		float xInput = Input.GetAxis("Horizontal");
		float zInput = Input.GetAxis("Vertical");
		directionVector.Set(xInput, 0.0f, zInput);
		directionVector.Normalize();
		
		controller.SimpleMove(this.directionVector * moveSpeed);
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {		
		
		Rigidbody body = hit.collider.attachedRigidbody;
		if(body == null || body.isKinematic) {
			return;
		}
		
		Vector3 pushDirection = new Vector3(hit.moveDirection.x, 0.0f, hit.moveDirection.y);
		body.velocity = pushDirection * pushPower;
	}
}
