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
	float allowedTimeBetweenButtons = 0.3f; //tweak as needed
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
		this.inputQueue = new Queue(4);
		Debug.Log("-----gameObject------");
		Debug.Log(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
		UpdateBARKInput();
		UpdateMovement();
	}
	
	
	
 
	void KeyCombo(string[] b)
	{
		buttons = b;
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
				return true;
			}
			else return false;
		}
		return false;
	}
	
	void UpdateBARKInput() {
		
		// get input
		//Debug.Log("Input Queue Count: " + this.inputQueue.Count);
		if(this.inputQueue.Count < 4) {
			//Debug.Log("Getting input");
			if(GetLeftBackLegInput()) {	
				// don't add duplicate
				if(this.inputQueue.Count > 0) {
					if(!this.inputQueue.Peek().Equals(LEFT_LEG_BACK_KEYCODE)) {
						this.inputQueue.Enqueue(LEFT_LEG_BACK_KEYCODE);
						Debug.Log("Adding A");			
					}
				}
				else if(this.inputQueue.Count == 0) {
					this.inputQueue.Enqueue(LEFT_LEG_BACK_KEYCODE);
					Debug.Log("Adding A");
				}
			}
			else if(GetLeftFrontLegInput()) {
				if(this.inputQueue.Count > 0) {
					if(!this.inputQueue.Peek().Equals(LEFT_LEG_FRONT_KEYCODE)) {
						this.inputQueue.Enqueue(LEFT_LEG_FRONT_KEYCODE);
						Debug.Log("Adding R");
					}
				}
				else if(this.inputQueue.Count == 0) {
					this.inputQueue.Enqueue(LEFT_LEG_FRONT_KEYCODE);
					Debug.Log("Adding R");
				}
			}
			else if(GetRightBackLegInput()) {			
				if(this.inputQueue.Count > 0) {
					if(!this.inputQueue.Peek().Equals(RIGHT_LEG_BACK_KEYCODE)) {
						this.inputQueue.Enqueue(RIGHT_LEG_BACK_KEYCODE);
						Debug.Log("Adding B");
					}
				}
				else if(this.inputQueue.Count == 0) {
					this.inputQueue.Enqueue(RIGHT_LEG_BACK_KEYCODE);
					Debug.Log("Adding B");
				}
			}
			else if(GetRightFrontLegInput()) {			
				if(this.inputQueue.Count > 0) {
					if(!this.inputQueue.Peek().Equals(RIGHT_LEG_FRONT_KEYCODE)) {
						this.inputQueue.Enqueue(RIGHT_LEG_FRONT_KEYCODE);
						Debug.Log("Adding K");
					}
				}
				else if(this.inputQueue.Count == 0) {
					this.inputQueue.Enqueue(RIGHT_LEG_FRONT_KEYCODE);
					Debug.Log("Adding K");
				}
			}
			
		}
		else { // process input
			Debug.Log("PROCESSING INPUT");
			// left back+front, right back+front
			if(this.inputQueue.Dequeue().Equals(RIGHT_LEG_FRONT_KEYCODE) && 
			this.inputQueue.Dequeue().Equals(RIGHT_LEG_BACK_KEYCODE) &&
			this.inputQueue.Dequeue().Equals(LEFT_LEG_FRONT_KEYCODE) &&
			this.inputQueue.Dequeue().Equals(LEFT_LEG_BACK_KEYCODE)) {
				// success!
				Debug.Log("MOVING");
				gameObject.transform.Translate(0, 50.0f, 0);
				this.inputQueue.Clear();
				return;
			}
			// right back+front, left back+front
			else if(this.inputQueue.Dequeue().Equals(LEFT_LEG_FRONT_KEYCODE) &&
			this.inputQueue.Dequeue().Equals(LEFT_LEG_BACK_KEYCODE) &&
			this.inputQueue.Dequeue().Equals(RIGHT_LEG_FRONT_KEYCODE) && 
			this.inputQueue.Dequeue().Equals(RIGHT_LEG_BACK_KEYCODE)) {
				// success!	
				Debug.Log("MOVING");
				gameObject.transform.Translate(0, 50.0f, 0);
				this.inputQueue.Clear();
				return;
			}
			
			//this.inputQueue.Clear();
		}
		
		// use when logic is more complicated
//		if(GetLeftBackLegInput()) {
//			if(this.inputQueue.Count > 0) {
//				if(this.state.Equals(MoveState.RightSideSuccess)) {
//					return; // sequence OK so far
//				}
//				if(this.inputQueue.Peek().Equals(RIGHT_LEG_BACK_KEYCODE) || this.inputQueue.Peek().Equals(RIGHT_LEG_FRONT_KEYCODE)) {
//					this.state = MoveState.Fail;
//					this.inputQueue.Clear();
//					return;
//				}
//			}
//			
//			this.inputQueue.Enqueue(LEFT_LEG_BACK_KEYCODE);
//		}
//		if(GetLeftFrontLegInput()) {
//			if(this.inputQueue.Count > 0) {
//				if(this.inputQueue.Peek().Equals(LEFT_LEG_BACK_KEYCODE)) {
//					if(this.state.Equals(MoveState.RightSideSuccess)) {
//						this.state = MoveState.BothSideSuccess;
//						this.inputQueue.Clear(); // sequence succeeded; reset input queue
//						return;
//					}
//					else {
//						this.state = MoveState.LeftSideSuccess;
//						this.inputQueue.Enqueue(LEFT_LEG_FRONT_KEYCODE);
//						return; // sequence OK so far
//					}								
//				}
//				else if(this.inputQueue.Peek().Equals(RIGHT_LEG_BACK_KEYCODE) || this.inputQueue.Peek().Equals(RIGHT_LEG_FRONT_KEYCODE)) {
//					this.state = MoveState.Fail;
//					this.inputQueue.Clear();
//					return;
//				}
//			}
//			
//			this.inputQueue.Enqueue(LEFT_LEG_FRONT_KEYCODE);
//		}
			
		
		// review this logic	
//		if(GetRightBackLegInput()) {			
//			if(!this.inputQueue.Peek().Equals(RIGHT_LEG_BACK_KEYCODE)) {
//				this.state = MoveState.LeftSideSuccess;	
//			}
//			this.inputQueue.Enqueue(RIGHT_LEG_BACK_KEYCODE);
//		}
//		if(GetRightFrontLegInput()) {			
//			if(!this.inputQueue.Peek().Equals(RIGHT_LEG_FRONT_KEYCODE)) {
//				this.state = MoveState.LeftSideSuccess;
//			}
//			this.inputQueue.Enqueue(RIGHT_LEG_FRONT_KEYCODE);
//		}
//		
//		if(this.state.Equals(MoveState.BothSideSuccess)) {
//			// clear move queue and start over
//			this.inputQueue.Clear();
//		}
		
//		foreach(KeyCode key in this.inputQueue) {
//			Debug.Log("KEY: " + key);
//		}
	}
	
	void UpdateMovement() {
		// translate dog based on state
		if(this.state.Equals(MoveState.LeftSideSuccess)) {
			Debug.Log("LEFT SUCCESS");
			this.state = MoveState.Idle;
		}
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
	
	bool GetCorrectLeftLegInput() {
		return this.state.Equals(MoveState.LeftSideSuccess);
		
//		if(GetLeftFrontLegInput()) {
//			if(this.inputQueue.Peek().Equals(LEFT_LEG_BACK_KEYCODE)) {
//				this.inputQueue.Enqueue(LEFT_LEG_FRONT_KEYCODE);
//				this.state = MoveState.LeftSideSuccess;
//				Debug.Log("LEFT LEGS OK");
//				return true;
//			}
//		}
//		
//		return false;
	}
	
	bool GetCorrectRightLegInput() {
		return this.state.Equals(MoveState.RightSideSuccess);
		
//		if(GetRightFrontLegInput()) {
//			if(this.inputQueue.Peek().Equals(RIGHT_LEG_BACK_KEYCODE)) {
//				this.inputQueue.Enqueue(RIGHT_LEG_FRONT_KEYCODE);
//				this.state = MoveState.RightSideSuccess;
//				Debug.Log("RIGHT LEGS OK");
//				return true;
//			}
//		}
//		
//		return false;
	}
	
	bool GetCorrectInputSequence() {
		return this.state.Equals(MoveState.BothSideSuccess);
	}
	
}
