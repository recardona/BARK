using UnityEngine;
using System.Collections;

public class LightbulbTriggerBehavior : MonoBehaviour {
	
	private Transform lightbulbLight;
	
	// Use this for initialization
	void Start () {
		lightbulbLight = transform.parent.Find("Lightbulb Light");
		
		if(!lightbulbLight) {
			Debug.LogError("LightbulbColliderBehavior.cs can't find associated Light GameObject.");
		}
	}
	
	void OnTriggerEnter(Collider other) {
		
		if(other.gameObject.tag == "Level") {
			lightbulbLight.SendMessage("BreakLightbulb");
		}
	}
}
