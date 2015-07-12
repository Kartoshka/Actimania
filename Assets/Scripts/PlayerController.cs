using UnityEngine;
using System.Collections;


public class PlayerController : MonoBehaviour {	
	private Collider currentTouching;

	public float speed;
	public float rotateSpeed;
	public int playerNumber;
	//Maybe use to dampen rotation and movement
	public float angularDrag, Drag;
	//Variable that controls the rotation 
	private Vector3 yR;
	public int ballsOnHand =0;


	//Allows dropping into tower
	bool touching;
	float dropTimer =0;
	public float dropLag;

	//Name of Inputs
	string[] Rotate = {"Rotate P1","Rotate P2"};
	string[] Move = {"Move P1","Move P2"};
	string[] Drop = {"Drop P1","Drop P2"};
	string[] Activate = {"Activate P1","Activate P2"};
	string[] Raise ={"Raise P1","Raise P2"};
	string[] Lower ={"Lower P1","Lower P2"};

	//Animation states and trigger names
	int stateAnim =0;
	string[] RaiseAnimation = {"Default","Raise 1","Raise 2","Raise 3"};
	string[] LowerAnimation = {"Default","Lower 1","Lower 2","Lower 3"};
	float[] speeds = {5f,4f,3f,2f};
	float animTimer =0;
	public float animLag;


	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis (Rotate[playerNumber-1]);
		float moveVertical = Input.GetAxis (Move[playerNumber -1]);




		//INPUTS
		bool raise = Input.GetButtonDown (Raise[playerNumber-1]);
		bool lower = Input.GetButtonDown (Lower[playerNumber-1]);
		bool FireBall = Input.GetButtonDown (Drop[playerNumber -1]);
		bool activateSwitch = Input.GetButtonDown (Activate[playerNumber -1]);


		//ANIMATION
		if (raise &&((Time.time - animTimer) >animLag)) 
			{
				if(stateAnim<4){
					stateAnim++;}
				gameObject.GetComponent<Animator>().SetTrigger(RaiseAnimation[stateAnim]);
			speed =speeds[stateAnim];
			animTimer = Time.time;
			Debug.Log (stateAnim);
			}
		else if(lower &&((Time.time - animTimer) >animLag))
			{
			gameObject.GetComponent<Animator>().SetTrigger(LowerAnimation[stateAnim]);


			if(stateAnim>0){
					stateAnim--;}
			speed =speeds[stateAnim];
			animTimer = Time.time;
			Debug.Log (stateAnim);
				
			}


		//MOVEMENT
		//Gets the direction vector of the object and moves it along that Z-X plane relative to its current position. Important to have transform.position+ movement otherwise oject snaps back to original place
		Vector3 movement = transform.forward;
		movement = movement* speed *Time.deltaTime *moveVertical;
		GetComponent<Rigidbody>().MovePosition (transform.position + movement);


		//Rotate the object around its y axis when clicked, relative to its original rotation, idk how the fuck Quaternions work
		yR = new Vector3 (0f,(moveHorizontal * rotateSpeed),0f);
		GetComponent<Rigidbody>().MoveRotation (GetComponent<Rigidbody>().rotation * Quaternion.Euler (yR));


		//DROP A BALL
		if (FireBall  && touching && ((Time.time - dropTimer) >dropLag)  && ballsOnHand >0 ){
			if((currentTouching.gameObject !=null) &&
			   currentTouching.gameObject.GetComponent<TowerController>().activated)
			{
				if(currentTouching.gameObject.GetComponent<TowerController>().towerID ==stateAnim){
						dropTimer = Time.time;
					dropBall(currentTouching);}
			}
		}
		//ACTIVATE A SWITCH
		if (activateSwitch && (currentTouching.gameObject !=null) &&(currentTouching.gameObject.tag == "actuator") ) {

				currentTouching.GetComponent<ActuatorController>().Activate();			
		}

	}
		
	void OnTriggerEnter(Collider other) {
		currentTouching = other;
		if (other.gameObject.tag == "GameBall" && ballsOnHand <10) {
			other.gameObject.GetComponent<BallManager>().isPickedUp(this.gameObject);

				}
		else if (other.gameObject.tag == "PointTower") {
			touching =true;
				}
	}
	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "PointTower") {
			touching =false;
		}
		}
	

	public void dropBall(Collider tower)
	{
		ballsOnHand--;
		tower.gameObject.GetComponent<TowerController>().ScorePoint ();

	}

	public void addBall()
	{
		ballsOnHand++;
	}
}
