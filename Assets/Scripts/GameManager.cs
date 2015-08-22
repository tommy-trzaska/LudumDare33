using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public RoomGenerator boardManager;
	public GameObject player;
	public int playerHealthPoints = 20;
	//public float levelStartDelay = 2f;

	//private Text levelText;
	//private GameObject levelImage;
	public int level = 1;
	private List<GameObject> boats;

	// Use this for initialization
	void Awake () 
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		DontDestroyOnLoad (gameObject);
		boats = new List<GameObject> ();
		boardManager = GetComponent<RoomGenerator> ();
		if (GameObject.FindGameObjectWithTag ("Player") == null)
			Instantiate (player);
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

		boats.Clear ();
		boardManager.SetupScene ();
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

	public void AddBoatToList (GameObject boat)
	{
		boats.Add (boat);
		Debug.Log (boat.name);
	}

	public void RemoveBoatFromList (GameObject boat)
	{
		boats.Remove (boat);
		Debug.Log (boats.Count);
		if (boats.Count <= 0)
		{
			Application.LoadLevel (Application.loadedLevel);
		}
	}
}
