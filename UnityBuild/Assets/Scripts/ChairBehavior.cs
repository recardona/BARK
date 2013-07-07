using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (BoxCollider))]
[RequireComponent (typeof (AudioSource))]

public class ChairBehavior : ObstacleBehavior 
{
	public AudioClip dragLoopSound;
	public AudioClip moveStopSound;
	
	void Start() {
		base.decibelLevel = 1;
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
