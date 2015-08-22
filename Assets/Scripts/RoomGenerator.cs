using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomGenerator : MonoBehaviour {

	public int columns = 8;
	public int rows = 8;
	public GameObject waterTile;
	public GameObject rockTile;

	private Transform boardHolder;
	private List<Vector3> gridPositions = new List<Vector3>();
	
	void InitializeList ()
	{
		gridPositions.Clear ();
		
		for (int x = 1; x < columns - 1; x++)
		{
			for (int y = 1; y < rows - 1; y++)
			{
				gridPositions.Add (new Vector3(x,y,0));
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

	// Use this for initialization
	void Start () 
	{
		BoardSetup ();
		InitializeList ();
	}
}
