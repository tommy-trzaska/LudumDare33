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
			GetComponent<Animator>().SetBool("warshipMove", true);

			if((target.position - transform.position).normalized.x > 0)
				transform.localScale = new Vector3(-1, 1, 1);
			else
				transform.localScale = Vector3.one;
		}
		else
			GetComponent<Animator>().SetBool("warshipMove", false);
	}

	bool CheckPath ()
	{
		if(target)
		{
			RaycastHit2D[] hit = Physics2D.RaycastAll (transform.position, target.position - transform.position, 1f);

			if (hit.Length > 1)
				return false;
		}
		else return false;

		return true;
	}
}
