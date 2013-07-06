using UnityEngine;
using System.Collections;

[RequireComponent (typeof (AudioSource))]

public class ChairBehavior : MonoBehaviour 
{
	void Start() {
	
	}
	
	void Update() {
		
	}
	
	void OnCollisionEnter(Collision collisionInfo) {
		// We were hit by the player
		if(collisionInfo.gameObject.tag == "Player") {
			audio.Play();
		}
	}
	
}
