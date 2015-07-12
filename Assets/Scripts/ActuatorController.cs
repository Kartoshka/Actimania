using UnityEngine;
using System.Collections;

public class ActuatorController : MonoBehaviour {
	public TowerController towerToSwitch;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Activate()
	{
		towerToSwitch.Switch ();
	}
}
