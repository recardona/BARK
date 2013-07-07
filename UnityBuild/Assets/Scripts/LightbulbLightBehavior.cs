using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Light))]
[RequireComponent (typeof (AudioSource))]

public class LightbulbLightBehavior : MonoBehaviour {
	
	public AudioClip onSound;
	public AudioClip breakSound;
	
	// Use this for initialization
	void Start () {
		
		if(!onSound) {
			Debug.LogError("LightbulbLightBehavior.cs has no Lightbulb On Sound attached.");
		}
		
		if(!breakSound) {
			Debug.LogError("LightbulbLightBehavior.cs has no Lightbulb Break Sound attached.");
		}
		
		audio.loop = true;
		audio.clip = onSound;
		audio.Play();
	}
	
	void BreakLightbulb() {
		// Turn off the light
		light.intensity = 0.0f;
		
		// Play the lightbulb break sound
		audio.Stop();
		audio.priority = 255;
		audio.volume =1.0f;
		audio.loop = false;
		audio.clip = breakSound;
		audio.Play();
	}
}
