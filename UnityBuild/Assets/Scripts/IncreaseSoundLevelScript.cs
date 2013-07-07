using UnityEngine;
using System.Collections;

public class IncreaseSoundLevelScript : MonoBehaviour {
	
	public int decibelLevelTotal = 0;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void UpdateDecibelLevel(int decibels) {
		this.decibelLevelTotal += decibels;
	}
	
	void OnGUI () {
		GUI.Label (new Rect (Screen.width-100, 300, 100, 50), decibelLevelTotal + "dBs");
	}
}
