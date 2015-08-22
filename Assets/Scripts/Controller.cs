using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {

	public int hp;
	public float speed;


	void Awake ()
	{
		if(GetComponent<Shooting>() == null && gameObject.tag != "Player")
		{
			GameManager.instance.AddBoatToList (gameObject);
		}
	}
}
