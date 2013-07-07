using UnityEngine;
using System.Collections;

public class BARKControlsScript : MonoBehaviour {
	
	private Queue inputQueue;
	private MoveState state;
	const KeyCode LEFT_LEG_BACK_KEYCODE = KeyCode.A;
	const KeyCode LEFT_LEG_FRONT_KEYCODE = KeyCode.R;
	const KeyCode RIGHT_LEG_BACK_KEYCODE = KeyCode.B;
	const KeyCode RIGHT_LEG_FRONT_KEYCODE = KeyCode.K;
//	KeyCode[] correctLegSequences = new KeyCode[] {
//										{KeyCode.A, KeyCode.R, KeyCode.B, KeyCode.K}, 
//										{KeyCode.B, KeyCode.K, KeyCode.A, KeyCode.R}};
	
	
	// Ref: http://wiki.unity3d.com/index.php/KeyCombo
	string[] buttons;
	private int currentIndex = 0; //moves along the array as buttons are pressed
	float allowedTimeBetweenButtons = 2.0f; //tweak as needed
	private float timeLastButtonPressed;
	
	enum MoveState {
		Idle = 0,
		LeftSideSuccess = 1, 
		RightSideSuccess = 2,
		BothSideSuccess = 3,
		Fail = 4
	}
	
	// Use this for initialization
	void Start () {
		//this.inputQueue = new Queue(4);		
		KeyCombo(null);
	}
	
	// Update is called once per frame
	void Update () {
		
		//UpdateBARKInput();
		//UpdateMovement();
		
		
		Check();
	}
	
	void KeyCombo(string[] b)
	{
		buttons = new string[]{"LEFT_BACK_LEG", "LEFT_FRONT_LEG", "RIGHT_BACK_LEG", "RIGHT_FRONT_LEG"};
	}
 
	//usage: call this once a frame. when the combo has been completed, it will return true
	bool Check()
	{
		if (Time.time > timeLastButtonPressed + allowedTimeBetweenButtons) currentIndex=0;
		if (currentIndex < buttons.Length)
		{
			if ((buttons[currentIndex] == "down" && Input.GetAxisRaw("Vertical") == -1) ||
			(buttons[currentIndex] == "up" && Input.GetAxisRaw("Vertical") == 1) ||
			(buttons[currentIndex] == "left" && Input.GetAxisRaw("Vertical") == -1) ||
			(buttons[currentIndex] == "right" && Input.GetAxisRaw("Horizontal") == 1) ||
			(buttons[currentIndex] != "down" &&  buttons[currentIndex] != "up" &&  buttons[currentIndex] != "left" &&  buttons[currentIndex] != "right" && Input.GetButtonDown(buttons[currentIndex])) )
			{
				timeLastButtonPressed = Time.time;
				currentIndex++;
			}
 
			if (currentIndex >= buttons.Length)
			{
				currentIndex = 0;
				Debug.Log("TRUE");
				gameObject.transform.Translate(Vector3.forward, Space.World);
				//RotateCharacter(5.0f);
				return true;
			}
			else return false;
		}
		return false;
	}
	
	void RotateCharacter(float rotation) {
		gameObject.transform.Rotate(gameObject.transform.forward, rotation);
	}
			
	void PushInputKey(KeyCode key) {
		this.inputQueue.Enqueue(key);
	}
	
	bool GetLeftBackLegInput() {
		return Input.GetKey("a");
	}
	
	bool GetLeftFrontLegInput() {
		return Input.GetKey("r");
	}
	
	bool GetRightBackLegInput() {
		return Input.GetKey("b");
	}
	
	bool GetRightFrontLegInput() {
		return Input.GetKey("k");
	}	
}
