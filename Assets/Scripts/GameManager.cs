using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int next = 0;
	private int nextToPosition = 0;
	private Vector3 lastPos;
	public GameObject player;
	public GameObject platformPrefab;
	private List<GameObject> monsters = new List<GameObject>();
	private List<GameObject> platforms = new List<GameObject>();
	private List<GameObject> items = new List<GameObject>();

	public GameObject platformGen;

	void Start ()
	{
		for (int i = 0; i < 30; i++)		// Pre make a pool of platforms
			MakePlatform(i);
		
		// Make first platform always under player
		platforms[0].transform.position = player.transform.position - new Vector3(0.0f, 3.0f, 0.0f);
		NextPlatformToPosition();
	}
	
	void Update ()
	{
		for (; this.platforms[PrevPlatformToPosition()].transform.position.x < platformGen.transform.position.x; NextPlatformToPosition())
		{
			print(nextToPosition + " | " + PrevPlatformToPosition());
			this.platforms[nextToPosition].transform.position = new Vector2(
																		Random.Range(this.platforms[PrevPlatformToPosition()].GetComponent<SpriteRenderer>().bounds.max.x + 10, this.platforms[PrevPlatformToPosition()].transform.position.x + 15), 
																		Random.Range(-6, 6));
		}
	}

	void FixedUpdate ()
	{


        // Simple verlet integration
        /*float dt = Time.fixedDeltaTime;
        Vector3 accel = -gravity * Vector3.up;

        Vector3 curPos = transform.position;
        Vector3 newPos = curPos + (curPos-lastPos) + impulse*Time.deltaTime + Physics.gravity*Time.deltaTime*Time.deltaTime;
        lastPos = curPos;
        transform.position = newPos;
        transform.forward = newPos - lastPos;

        impulse = Vector3.zero;

        // Z-kill
        if (transform.position.y < -5f)
            Destroy(gameObject);*/
	}

	public GameObject MakeMonster()
	{
		return new GameObject();
	}

	public void MakePlatform(int index)
	{
		GameObject platform = Instantiate(platformPrefab);
		platform.name = "Platform";
		this.platforms.Add(platform);
	}

	private void PositionNextPlatform()
	{
		
	}

	public GameObject MakeItem()
	{
		return new GameObject();
	}

	/*public void SetPlayerPlatform(GameObject platform)
	{
		for(int i = 0; i < platforms.Count; i++)
			if (platform == platforms[i])
			{
				this.next = i;
				return;
			}
	}*/

	// ######### Utility funcitons #########

	void NextPlatform()
	{
		next = ++next % platforms.Count;
	}

	void NextPlatformToPosition()
	{
		nextToPosition = mod(++nextToPosition, platforms.Count);
	}

	int PrevPlatformToPosition()
	{
		return mod(nextToPosition - 1, platforms.Count);
	}

	int mod(int x, int m)
	{	
		print(x + " - " + m);
    	return (x%m + m)%m;
	}
}
