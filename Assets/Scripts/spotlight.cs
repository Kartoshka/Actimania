using UnityEngine;
using System.Collections;

public class spotlight : MonoBehaviour {

	public int amountX  =1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.rotation.eulerAngles.x < 70 && transform.rotation.eulerAngles.z <=0 ) {
						amountX = 1;
				}
		else if(transform.rotation.eulerAngles.x <70 && transform.rotation.eulerAngles.z >0)
		{
			amountX =-1;
		}



		   transform.Rotate (new Vector3 (amountX, 0, 0)* 0.5f);
				
	}
}
