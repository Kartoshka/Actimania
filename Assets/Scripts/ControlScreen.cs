using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ControlScreen : MonoBehaviour {
	public Text coins;
	private int numCoins =0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		bool enter = Input.GetButtonDown ("Submit");
		bool enterCoin = Input.GetButtonDown ("Cancel");

		if (enterCoin) {
			numCoins ++;		
		}
		if(enter && (numCoins>0)){
			Application.LoadLevel ("MainScene");		
		}
		coins.text = "Coins/Monnaie: " + numCoins;
	
	}
}
