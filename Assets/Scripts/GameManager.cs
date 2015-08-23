using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public RoomGenerator boardManager;
	public GameObject playerPrefab;
	public GameObject player;
	public Text pointsText;

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
		{
			player = (GameObject)Instantiate (playerPrefab);
		}
		InitGame ();
	}

	private void OnLevelWasLoaded (int index)
	{
		level++;
		InitGame ();

		if(pointsText == null)
			pointsText = GameObject.Find ("PointsText").GetComponent<Text>();
		
		pointsText.text = "Level " + GameManager.instance.level;
	}

	void InitGame ()
	{
		MenuMenager.instance.menuScreen.SetActive (false);

		boats.Clear ();
		boardManager.SetupScene ();
	}

	public void GameOver ()
	{
		MenuMenager.instance.GameOverScreen.SetActive (true);
		boardManager.boardHolder.gameObject.SetActive (false);
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
