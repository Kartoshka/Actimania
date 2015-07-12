using UnityEngine.UI;
using UnityEngine;
using System.Collections;
using System.Threading;

public class game : MonoBehaviour {
	public int scoreP1;
	public int scoreP2;
	public float LengthGame;
	private float currentTime;
	public float displayTimeM;
	public float displayTimeS;
	private float startLevel;

	public Text displayer;

	public GameObject ball;
	public GameObject field;
	// Use this for initializatio
	private float ballSpawn =0;
	private int ballsOnField;
	public float ballSpawnTimer;
	public int maxBalls;
	private float neg1 = -1;

	public Animator camera;
	public GameObject UI;

	private float startTime;

	void Start()
	{
		camera.SetTrigger ("Go");

		startTime = Time.time;
		
	}
	// Update is called once per frame
	void Update () {
		if ((Time.time -startTime) > 5) {
			UI.SetActive(true);

						currentTime = Time.time - startLevel -5;
						displayTimeM = ((LengthGame - currentTime) / 60);
						displayTimeS = (LengthGame - currentTime) % 60;
						
			string time;
			if(displayTimeS<10){
				time =(int)displayTimeM + ":0" + (int)displayTimeS;
			}
			else
			{
				 time =(int)displayTimeM + ":" + (int)displayTimeS;
			}

				displayer.text = time;

						if ((currentTime - ballSpawn) > ballSpawnTimer && ballsOnField < maxBalls) {
								ballSpawn = currentTime;
								createBall ();
						}
						if (currentTime >= LengthGame) {
								Application.LoadLevel ("endGame");
						}
				}
				
	}

	void createBall()
	{

		Vector3 position = new Vector3(Random.Range(field.GetComponent<Renderer>().bounds.extents.x *neg1,field.GetComponent<Renderer>().bounds.extents.x),
		                               0.1f,Random.Range(field.GetComponent<Renderer>().bounds.extents.z *neg1,field.GetComponent<Renderer>().bounds.extents.z));
		Instantiate(ball,position,Quaternion.identity);
		ballsOnField++;
	}

	void Awake()
	{
		startLevel = Time.time;
		DontDestroyOnLoad (this);
	}
}
