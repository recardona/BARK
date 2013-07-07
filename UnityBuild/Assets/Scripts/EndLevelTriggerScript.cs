using UnityEngine;
using System.Collections;

public class EndLevelTriggerScript : MonoBehaviour {
	private bool isLevelComplete = false;
	
	void OnTriggerEnter(Collider other) {
		isLevelComplete = true;
		//Debug.Log("LEVEL COMPLETED");
//		GUIText endLevelText = new GUIText();
//		endLevelText.text = "Level Completed!!";
//		endLevelText.alignment = TextAlignment.Center;
//		endLevelText.enabled = true;
		
		//Debug.Log(endLevelText);
    }
	
	void OnGUI () {
		if(isLevelComplete) {
			GUI.Label (new Rect (100, 300, 100, 50), "LEVEL COMPLETED!!");
		}
	}
}
