using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Diagnostics;

public class winner : MonoBehaviour {

	public GameObject musicSource;
	private AudioSource music;
	private game world;
	private string Winner;
	// Use this for initialization
	void Start () {
		music = musicSource.GetComponent<AudioSource> ();
		world = GameObject.FindGameObjectWithTag("World").GetComponent<game>();
		if (world.scoreP1 > world.scoreP2) {
						Winner = "Vanier wins. Initializing Portal \nVanier gagne. Ouverture du portail.";	
						music.Play();
				} else if (world.scoreP2 > world.scoreP1) {
						Winner = "Player 2 wins";		
				} else {
						Winner = "It's a tie..... ";
				}
		GameObject fk =GameObject.FindGameObjectWithTag ("World");
		Destroy (fk);

		Process.Start ("tron_hack_stojda.exe");

	
	}
	
	// Update is called once per frame
	void Update () {
		UnityEngine.Debug.Log (Time.time);

			

		gameObject.GetComponent<Text> ().text = Winner;
		bool restart = Input.GetButton("Restart");
		if (restart) {
			Destroy (this);
			Application.LoadLevel("MainScene");

				}
	}
}
