using UnityEngine;
using System.Collections;

public class Loader : MonoBehaviour {

	public GameObject gameManager;

	// Use this for initialization
	void Awake () 
	{

	}

	public void StartGame ()
	{
		MenuMenager.instance.menuScreen.SetActive (false);
		if (GameManager.instance == null)
		{
			Instantiate (gameManager);
		}
	}
}
