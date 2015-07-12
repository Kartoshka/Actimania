using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void isPickedUp(GameObject p)
	{

		if (p.GetComponent<PlayerController> () != null) {
					Destroy (gameObject);
					PlayerController player = p.GetComponent<PlayerController> ();
					player.addBall ();

						
				}

	}
	
}
