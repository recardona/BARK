using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (BoxCollider))]
[RequireComponent (typeof (AudioSource))]

public class ChairBehavior : MonoBehaviour 
{
	public AudioClip dragLoopSound;
	public AudioClip moveStopSound;
	
	void Start() {
	
	}
	
	void Update() {
		
	}
	
	void OnCollisionEnter(Collision collisionInfo) {
		// We were hit by the player
		if(collisionInfo.gameObject.tag == "Player") {
			audio.clip = dragLoopSound;
			audio.loop = true;
			audio.Play();
			
		}
	}
	
	void OnCollisionExit(Collision collisionInfo) {
		audio.loop = false;
		audio.clip = moveStopSound;
		audio.Play();
	}
	
}
