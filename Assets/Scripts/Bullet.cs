using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public int damage = 1;
	public float speed = 10;
	public float range = 5;
	public Vector3 direction;

	private float currentDist = 0;

	void OnEnable ()
	{
		currentDist = 0;

	}
	
	// Update is called once per frame
	void Update () 
	{
		currentDist += speed * Time.deltaTime;

		transform.Translate (direction * speed * Time.deltaTime);

		if(currentDist >= range)
			gameObject.SetActive (false);
	}

	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<Player>().hp -= damage;
			gameObject.SetActive (false);
			if(other.gameObject.GetComponent<Player>().hp <=0)
			{
				Destroy (other.gameObject);
				GameManager.instance.GameOver ();
			}
		}
	}
}
