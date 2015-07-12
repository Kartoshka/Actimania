using UnityEngine.UI;
using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {
	public game world;
	float score1;
	float score2;
	Text text1;
	Text text2;
	// Use this for initialization
	void Start () {
		text1 = gameObject.transform.Find("P1").gameObject.GetComponent<Text> ();
		text2 = gameObject.transform.Find ("P2").gameObject.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {		 
		text1.text= "VANIER : " + world.scoreP1;
		text2.text= "TRON : " + world.scoreP2;

	}
}
	