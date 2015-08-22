using UnityEngine;
using System.Collections;

public class Player : Controller {

	public int damage = 1;

	private GameObject target;

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
			}
		}
	}

	void OnCollisionEnter2D (Collision2D col)
	{
		if(col.collider.gameObject.tag == "Boat")
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
}