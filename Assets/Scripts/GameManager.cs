using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public RoomGenerator boardManager;
	//public int playerFoodPoints = 100;
	//public float turnDelay = 0.1f;
	//public float levelStartDelay = 2f;
	//[HideInInspector] public bool playersTurn = true;

	//private Text levelText;
	//private GameObject levelImage;
	[SerializeField]
	private int level = 1;
	//private List<Enemy> enemies;
	//private bool enemiesMoving;
	//private bool doingSetup;

	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		//enemies = new List<Enemy> ();
		boardManager = GetComponent<RoomGenerator> ();
		InitGame ();
	}

	private void OnLevelWasLoaded (int index)
	{
		level++;
		InitGame ();
	}

	void InitGame ()
	{
		//doingSetup = true;

		//levelImage = GameObject.Find ("LevelImage");
		//levelText = GameObject.Find ("LevelText").GetComponent<Text>();
		//levelText.text = "Day " + level;
		//levelImage.SetActive (true);
		//Invoke ("HideImage", levelStartDelay);

		//enemies.Clear ();
		boardManager.SetupScene (level);
	}

	private void HideImage ()
	{
		//levelImage.SetActive (false);
		//doingSetup = false;
	}

	public void GameOver ()
	{
		//levelText.text = "After " + level + " days, you starved.";
		//levelImage.SetActive (true);
		enabled = false;
	}

	// Update is called once per frame
	void Update () 
	{

	}
}
