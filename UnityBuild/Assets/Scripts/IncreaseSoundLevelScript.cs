using UnityEngine;
using System.Collections;

public class IncreaseSoundLevelScript : MonoBehaviour {
	
	public int decibelLevelTotal = 0;
	public int decibelLevelLoseCondition = 1;
	private bool decibelLimitReached = false;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(decibelLimitReached) {
			if(Input.GetKey("e")) {
				Application.LoadLevel(0);
			}
		}
	}
	
	void UpdateDecibelLevel(int decibels) {
		this.decibelLevelTotal += decibels;
		if(this.decibelLevelTotal >= this.decibelLevelLoseCondition) {
			this.decibelLimitReached = true;
		}
	}
	
	void OnGUI () {
		if(!this.decibelLimitReached) {
			GUI.Label (new Rect (Screen.width-100, 300, 100, 50), decibelLevelTotal + "dBs");
		}
		else {
			GUI.Label (new Rect (Screen.width-100, 300, 100, 50), "GAME OVER ... Press E to Restart");
		}
	}
}
