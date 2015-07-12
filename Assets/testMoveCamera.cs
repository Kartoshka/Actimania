using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class testMoveCamera : MonoBehaviour {

	public float xMovement;
	public float yMovement;
	public float zMovement;
	public float timerUpdate;
	private float time;
	public Text welcome;

	private bool rotated =false; 
	
	// Use this for initialization
	void Start () {
		
		time = 2f;

	}
	
	// Update is called once per frame
	void Update () {
		if (Time.time > 1) {
			welcome.enabled =false;
			Pan();
				}


	}

	void Pan()
	{

		if((Time.time - time) >= timerUpdate) {

			gameObject.transform.position = new Vector3 (transform.position.x +xMovement ,
			                                             transform.position.y +yMovement,
			                                             transform.position.z );
			time = Time.time;
			
		}
		if ((transform.position.x < -6.31f) && (transform.position.y > 3.84f)) {
			this.enabled = false;
		}
	}
}
