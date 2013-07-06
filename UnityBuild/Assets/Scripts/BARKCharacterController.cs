using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]

/**
 * The BARKCharacterController is a CharacterController, which uses RigidBody
 * dynamics and a CapsuleCollider.
 */
public class BARKCharacterController : MonoBehaviour 
{
	public float moveSpeed = 3.0f;
	public float gravity   = 9.8f;
	public float maxVelocityChange = 10.0f;
	public float jumpHeight = 2.0f;
	public bool  canJump = true;
	
	private bool grounded = false;
	
	void Awake() {
		rigidbody.freezeRotation = true;
		rigidbody.useGravity = false;
	}
		
	void FixedUpdate() {
		
		if(grounded) {
			// Calculate how fast we should be moving.
			float xInput = Input.GetAxis("Horizontal");
			float zInput = Input.GetAxis("Vertical");
			Vector3 targetVelocity = new Vector3(xInput, 0.0f, zInput);
			targetVelocity.Normalize();
			
			targetVelocity = transform.TransformDirection(targetVelocity);
			targetVelocity *= moveSpeed;
			
			// Apply a force that attempts to reach our target velocity.
			Vector3 currentVelocity = rigidbody.velocity;
			Vector3 velocityDelta = (targetVelocity - currentVelocity);
			velocityDelta.x = Mathf.Clamp(velocityDelta.x, -maxVelocityChange, maxVelocityChange);
			velocityDelta.z = Mathf.Clamp(velocityDelta.z, -maxVelocityChange, maxVelocityChange);
			velocityDelta.y = 0.0f;
			rigidbody.AddForce(velocityDelta, ForceMode.VelocityChange);
		}
		
		// We apply gravity manually for more tuning control.
		rigidbody.AddForce(new Vector3(0.0f, (-gravity*rigidbody.mass), 0.0f));
		
		// We cannot be sure if the object is grounded, so, let's assume no.
		// Let the collision against the ground verify that we have in fact landed.
		grounded = false;
	}
	
	void OnCollisionStay() {
		grounded = true;
	}
	
}
