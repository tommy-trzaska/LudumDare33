using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : Controller {

	public int damage = 1;
	public Text healthText;


	private int points = 0;

	private GameObject target;

	void Awake ()
	{

		DontDestroyOnLoad (this);
	}

	void OnDisable ()
	{
		healthText.text = hp.ToString ();
	}

	void Update () 
	{
		float vertical = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float horizontal = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		Vector3 direction = new Vector3 (horizontal, vertical, 0);

		GetComponent<Rigidbody2D> ().MovePosition (transform.position + direction);

		if(target && Input.GetMouseButtonDown (0))
		{
			target.GetComponent<Controller>().hp -= damage;

			if(target.GetComponent<Controller>().hp <= 0)
			{
				target.gameObject.SetActive (false);
				if(target.gameObject.tag == "Boat")
					GameManager.instance.RemoveBoatFromList (target.gameObject);

				target = null;
			}
		}

		if(healthText == null)
			healthText = GameObject.Find ("healthText").GetComponent<Text>();

		healthText.text = hp.ToString ();
	}

	void OnCollisionStay2D (Collision2D col)
	{
		if(col.collider.gameObject.tag == "Boat" || col.collider.gameObject.tag == "Warship")
		{
			target = col.collider.gameObject;
		}
	}

	void OnCollisionExit2D (Collision2D col)
	{
		if(col.collider.gameObject == target)
		{
			target = null;
			Debug.Log ("target lost");
		}
	}
	
	void OnTriggerEnter2D (Collider2D other)
	{
		if(other.gameObject.tag == "Fish")
		{
			Destroy (other.gameObject);
			hp++;
		}
	}
}