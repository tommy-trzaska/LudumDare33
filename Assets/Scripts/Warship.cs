using UnityEngine;
using System.Collections;

public class Warship : Controller {

	private Transform target;

	// Use this for initialization
	void Awake () 
	{
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		speed = 0.2f * GameManager.instance.level;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(CheckPath ())
		{
			transform.Translate ((target.position - transform.position).normalized * speed * Time.deltaTime);
		}
	}

	bool CheckPath ()
	{
		if(target)
		{
			RaycastHit2D[] hit = Physics2D.RaycastAll (transform.position, target.position - transform.position, 1f);

			if (hit.Length > 1)
				return false;
		}

		return true;
	}
}
