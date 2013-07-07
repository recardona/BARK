using UnityEngine;
using System.Collections;

public class EndLevelTriggerScript : MonoBehaviour {
	private bool isLevelComplete = false;
	
	void OnTriggerEnter(Collider other) {
		isLevelComplete = true;
    }
	
	void OnGUI () {
		if(isLevelComplete) {
			GUI.Label (new Rect (100, 300, 100, 50), "LEVEL COMPLETED!!");
		}
	}
}
