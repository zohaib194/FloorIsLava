using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int next = 0;
	public GameObject player;
	public GameObject platformPrefab;
	private List<GameObject> monsters = new List<GameObject>();
	private List<GameObject> platforms = new List<GameObject>();
	private List<GameObject> items = new List<GameObject>();

	void Start ()
	{
		for (int i = 0; i < 30; i++)		// Pre make a pool of platforms
			MakePlatform(i);
		
		// Make first platform always under player
		platforms[0].transform.position = player.transform.position - new Vector3(0.0f, 3.0f, 0.0f);
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

	public void MakePlatform(int index)
	{
		GameObject platform = Instantiate(platformPrefab);
		platform.name = "Platform: " + index.ToString(); 
		this.platforms.Add(platform);
	}

	public GameObject MakeItem()
	{
		return new GameObject();
	}

	// ######### Utility funcitons #########

	void PlatformShiftRight()
	{
		next = ++next % platforms.Count;
	}

	void PlatformShiftLeft()
	{
		next = mod(--next, platforms.Count);
	}

	int mod(int x, int m)
	{
    	return (x%m + m)%m;
	}
}
