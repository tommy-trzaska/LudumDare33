using UnityEngine;
using System.Collections;

public class Player : Controller {


	void Update () 
	{
		float vertical = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		float horizontal = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;
		Vector3 direction = new Vector3 (horizontal, vertical, 0);

		GetComponent<Rigidbody2D> ().MovePosition (transform.position + direction);
	}


}
