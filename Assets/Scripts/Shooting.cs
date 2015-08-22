using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {

	public GameObject bulletPrefab;
	public int bulletsCount = 20;
	public float firingRate = 0.5f;
	public Transform target;

	private GameObject[] bulletsArray;
	private float shootPause = 0;

	void CreateBullets ()
	{
		bulletsArray = new GameObject[bulletsCount];

		for (int i = 0; i < bulletsCount; i++)
		{
			bulletsArray[i] = (GameObject)Instantiate (bulletPrefab);
			bulletsArray[i].SetActive (false);
		}
	}

	// Use this for initialization
	void Awake () 
	{
		CreateBullets ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () 
	{
		shootPause += Time.deltaTime;

		if(shootPause >= firingRate && target != null)
		{
			if(Vector2.Distance (transform.position, target.position) < 3)
				Shoot ();
		}
	}

	void Shoot ()
	{

		shootPause = 0;
		foreach (GameObject bullet in bulletsArray)
		{
			if(!bullet.activeInHierarchy)
			{
				Debug.Log ("Shoot");
				bullet.SetActive (true);
				bullet.GetComponent<Bullet>().direction = (target.position - transform.position).normalized;
				bullet.transform.position = transform.position;
				break;
			}
		}
	}
}
