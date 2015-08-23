using UnityEngine;
using System.Collections;

public class MenuMenager : MonoBehaviour {

	public static MenuMenager instance;
	public GameObject menuScreen;
	public GameObject GameOverScreen;

	void Awake ()
	{
		instance = this;
	}

	public void TryAgain ()
	{
		GameManager.instance.level = 0;
		GameManager.instance.player.GetComponent<Player> ().hp = 10;
		GameManager.instance.player.SetActive (true);
		GameManager.instance.player.transform.position = Vector2.zero;
		Application.LoadLevel (Application.loadedLevel);
	}
}
