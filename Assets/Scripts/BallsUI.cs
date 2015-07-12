using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class BallsUI : MonoBehaviour {

	string text = "";
	public GameObject player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		for (int i =1; i <=player.GetComponent<PlayerController> ().ballsOnHand; i++) {
			text = text + " O ";
				}

		gameObject.GetComponent<Text> ().text =text;
		text = "";
	}
}
