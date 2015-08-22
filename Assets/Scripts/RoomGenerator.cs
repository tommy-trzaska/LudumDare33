using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class RoomGenerator : MonoBehaviour {

	[Serializable]
	public class Count
	{
		public int minimum;
		public int maximum;
		
		public Count (int min, int max)
		{
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 8;
	public int rows = 8;
	public GameObject waterTile;
	public GameObject rockTile;
	public GameObject fishingBoat;
	public GameObject fishPowerup;
	public GameObject warship;
	public Count fishersCount = new Count(5,9);
	public Count powerupCount = new Count (0, 3);

	private Transform boardHolder;
	private List<Vector3> gridPositions = new List<Vector3>();
	
	void InitializeList ()
	{
		gridPositions.Clear ();
		
		for (int x = 1; x < columns - 1; x++)
		{
			for (int y = 1; y < rows - 1; y++)
			{
				gridPositions.Add (new Vector3(x * 1.28f,y * 1.28f,0));
			}
		}
	}

	void BoardSetup ()
	{
		boardHolder = new GameObject ("Board").transform;
		
		for (int x = -1; x < columns + 1; x++)
		{
			for (int y = -1; y < rows + 1; y++)
			{
				GameObject instance = (GameObject)Instantiate(waterTile, new Vector3(x * 1.28f,y * 1.28f,0), Quaternion.identity);
				instance.transform.parent = boardHolder;

				if(x == -1 || x == columns || y == -1 || y == rows)
				{
					instance = (GameObject)Instantiate(rockTile, new Vector3(x * 1.28f,y * 1.28f,0), Quaternion.identity);
					instance.transform.parent = boardHolder;
				}
			}
		}
	}

	Vector3 RandomPosition ()
	{
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex);
		return randomPosition;
	}

	void LayoutObjectAt (GameObject tile, int minimum, int maximum)
	{
		int objectCount = Random.Range (minimum, maximum + 1);
		
		for (int i = 0; i < objectCount; i++)
		{
			Vector3 randomPosition = RandomPosition ();
			Instantiate (tile, randomPosition, Quaternion.identity);
		}
	}

	// Use this for initialization
	public void SetupScene () 
	{
		int level = GameManager.instance.level;
		BoardSetup ();
		InitializeList ();
		LayoutObjectAt (fishingBoat, fishersCount.minimum, fishersCount.maximum);
		LayoutObjectAt (fishPowerup, powerupCount.minimum, powerupCount.maximum);

		int enemiesCount = (int)Mathf.Log (level, 2f);
		LayoutObjectAt (warship, enemiesCount, enemiesCount);
	}
}
