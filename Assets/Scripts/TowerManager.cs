using UnityEngine;
using System.Collections;

public class TowerManager : MonoBehaviour {

	public int P1Multiplier;
	public int  P2Multiplier;
	private int[] controller = new int[3];
	// Use this for initialization

	void Start()
	{
		for (int i =0; i<3; i++) {
			controller [i] = 0;
				}
	}
	// Update is called once per frame
	void Update () {
		for (int i =0; i<3; i++) {
			if(transform.GetChild (i).gameObject.GetComponent<TowerController> ().activated){
				controller [i] = transform.GetChild (i).gameObject.GetComponent<TowerController> ().playerControlling;}


		}
		P1Multiplier = countElements (controller, 1);
		P2Multiplier = countElements (controller, 2);
	}

	int countElements(int[] array, int element)
	{
		int count = 0;
		for(int i =0;i<array.Length;i++)
		{
			if(array[i] == element)
			{
				count++;
			}
		}
		return count;
	}
}


