using UnityEngine;
using System.Collections;

public class LightbulbTriggerBehavior : ObstacleBehavior {
	
	private Transform lightbulbLight;
	
	// Use this for initialization
	void Start () {
		base.decibelLevel = 10;
		lightbulbLight = transform.parent.Find("Lightbulb Light");
		
		if(!lightbulbLight) {
			Debug.LogError("LightbulbColliderBehavior.cs can't find associated Light GameObject.");
		}
	}
	
	void OnTriggerEnter(Collider other) {
		
		if(other.gameObject.tag == "Level") {
			lightbulbLight.SendMessage("BreakLightbulb");
			IncreaseSoundLevelScript soundLevelScript = GameObject.Find("Real Dog").GetComponent<IncreaseSoundLevelScript>();
			soundLevelScript.SendMessage("UpdateDecibelLevel", this.decibelLevel);
		}
	}
}
