using UnityEngine;
using System.Collections;

public class EndLevelTriggerScript : MonoBehaviour {
	void OnTriggerEnter(Collider other) {
		Debug.Log("LEVEL COMPLETED");
    }
}
