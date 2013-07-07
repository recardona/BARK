using UnityEngine;
using System.Collections;

public class EndLevelTriggerScript : MonoBehaviour {
	public string levelCompleteMessage = "LEVEL COMPLETED!! Press E to restart";
	private bool isLevelComplete = false;
	
	void Update() {
		if(isLevelComplete) {
			if(Input.GetKey("e")) {
					Application.LoadLevel(0);
			}
		}	
	}
	
	void OnTriggerEnter(Collider other) {
		isLevelComplete = true;
    }
	
	void OnGUI () {
		if(isLevelComplete) {
			GUI.Label (new Rect (100, 300, 100, 50), levelCompleteMessage);			
			if(Input.GetKey("e")) {
				Application.LoadLevel(0);
			}
		}
	}
}
