using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private Vector2Int range = new Vector2Int(0, 7);
	public GameObject player;
	private List<GameObject> monsters = new List<GameObject>();
	private List<GameObject> platforms = new List<GameObject>();
	private List<GameObject> items = new List<GameObject>();

	void Start ()
	{
		for (int i = 0; i < 30; i++)		// Pre make a pool of platforms
			platforms.Add(MakePlatform(i));
	}
	
	void Update ()
	{
		this.HandleInput();
	}

	private void HandleInput()
	{
		// Place input code here!
	}

	public GameObject MakeMonster()
	{
		return new GameObject();
	}

	public GameObject MakePlatform(int index)
	{
		GameObject platform = new GameObject();
		platform.name = index.ToString(); 
		return platform;
	}

	public GameObject MakeItem()
	{
		return new GameObject();
	}

	// ######### Utility funcitons #########

	void PlatformShiftRight()
	{
		range.x = ++range.x % platforms.Count;
		range.y = ++range.y % platforms.Count;
	}

	void PlatformShiftLeft()
	{
		range.x = mod(--range.x, platforms.Count);
		range.y = mod(--range.y, platforms.Count);
	}

	int mod(int x, int m)
	{
    	return (x%m + m)%m;
	}
}
