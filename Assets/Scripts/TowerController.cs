using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerController : MonoBehaviour {

	public int playerControlling;
	public int point;

	public game world; 
	Color def = Color.red;
	Color player2 = Color.blue;
	Color player1 =Color.yellow;

	Color[] currentColor; 
	public int cC;
	public bool activated = false;

	public int towerID;

	private int P1Multiplier;
	private int P2Multiplier;

	void Start () {
		currentColor = new Color[2];
		currentColor [0] = player1;
		currentColor [1] = player2;

		gameObject.GetComponent<Renderer>().material.color = def;

	}
	// Update is called once per frame
	void Update () {
		P1Multiplier = transform.parent.GetComponent<TowerManager> ().P1Multiplier;
		P2Multiplier = transform.parent.GetComponent<TowerManager> ().P2Multiplier;
	}

	public void Switch()
	{
		activated = true;
		if (cC == 0) {
				cC = 1;
				playerControlling = 2;
		} else {
				cC = 0;
				playerControlling = 1;
		}
		gameObject.GetComponent<Renderer>().material.color = currentColor [cC];				 

	}

	public void ScorePoint()
	{
		if (activated) {
						if (playerControlling == 1) {
								world.scoreP1 += point * P1Multiplier; 
						} else {
								world.scoreP2 += point * P2Multiplier;
						}
				}
	}
}
