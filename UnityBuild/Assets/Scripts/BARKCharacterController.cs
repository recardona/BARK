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
	public float moveSpeed = 100.0f;
	public float gravity   = 9.8f;
	public float maxVelocityChange = 1000.0f;
	public float jumpHeight = 2.0f;
	public bool  canJump = true;
	
	private bool grounded = false;
	
	// Ref: http://wiki.unity3d.com/index.php/KeyCombo
	private string[] buttons;
	private int currentIndex = 0; //moves along the array as buttons are pressed
	private float allowedTimeBetweenButtons = 1.0f; //tweak as needed
	private float timeLastButtonPressed;	
	
	void Awake() {
		rigidbody.freezeRotation = true;
		rigidbody.useGravity = false;
		//buttons = new string[]{"LEFT_BACK_LEG", "LEFT_FRONT_LEG", "RIGHT_BACK_LEG", "RIGHT_FRONT_LEG"};
		buttons = new string[]{"LEFT_BACK_LEG"};
	}
		
	void FixedUpdate() {
		
		if(grounded) {
			
			// Calculate how fast we should be moving.
			Vector3 targetVelocity = Vector3.zero;
			
			if(InputIsKeySequence())
			{
				targetVelocity = Vector3.forward*moveSpeed;
			}

			targetVelocity = transform.TransformDirection(targetVelocity);
			//Debug.Log(""+targetVelocity);
			//targetVelocity *= moveSpeed;
			
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
	
	void OnCollisionEnter(Collision other) {
		if(other.gameObject.tag != "Level") {
			Debug.Log("Dog collided");

			IncreaseSoundLevelScript soundLevelScript = gameObject.GetComponent<IncreaseSoundLevelScript>();
			//soundLevelScript.SendMessage("")
			Debug.Log(soundLevelScript);
			soundLevelScript.SendMessage("UpdateDecibelLevel", other.gameObject.GetComponent<ChairBehavior>().GetDecibelLevel());			
		}
	}
	
	void OnCollisionStay() {
		grounded = true;
	}
	
	
	//usage: call this once a frame. when the combo has been completed, it will return true
	bool InputIsKeySequence()
	{
		if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex=0;
		if (currentIndex < buttons.Length)
		{
			if ((buttons[currentIndex] == "down" && Input.GetAxisRaw("Vertical") == -1) ||
			(buttons[currentIndex] == "up" && Input.GetAxisRaw("Vertical") == 1) ||
			(buttons[currentIndex] == "left" && Input.GetAxisRaw("Vertical") == -1) ||
			(buttons[currentIndex] == "right" && Input.GetAxisRaw("Horizontal") == 1) ||
			(buttons[currentIndex] != "down" &&  buttons[currentIndex] != "up" &&  buttons[currentIndex] != "left" &&  buttons[currentIndex] != "right" && Input.GetButtonDown(buttons[currentIndex])) )
			{
				timeLastButtonPressed = Time.time;
				currentIndex++;
			}
 
			if (currentIndex >= buttons.Length)
			{
				currentIndex = 0;
				return true;
			}
			
			else
			{
				return false;	
			}
		}
		return false;
	}
	
}
