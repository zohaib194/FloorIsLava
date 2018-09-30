using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private int nextPlatform = 0;
	private int nextPlatformToPosition = 0;
	private int nextMonster = 0;
	private int nextMonsterToPosition = 0;
	private Vector3 lastPos;
	public GameObject player;
	public GameObject ground;
	public GameObject monsterPrefab;
	public GameObject platformPrefab;
	public GameObject HpPotionPrefab;
	public GameObject ManaPotionPrefab;
	private List<GameObject> monsters = new List<GameObject>();
	private List<GameObject> platforms = new List<GameObject>();
	private List<GameObject> items = new List<GameObject>();
	private Camera cam;


	public GameObject platformGen;

	void Start ()
	{
		cam = Camera.main;
		for (int i = 0; i < 30; i++) {		// Pre make a pool of platforms
			MakePlatform();
			MakeMonster();
		}
		
		// Make first platform always under player
		platforms[0].transform.position = player.transform.position - new Vector3(0.0f, 3.0f, 0.0f);
		NextPlatformToPosition();
		monsters[0].transform.position = new Vector3(ground.transform.position.x, ground.transform.position.y + 15.7f, 0.0f);
		NextMonsterToPosition();
	}
	
	void Update ()
	{
		for (; this.platforms[PrevPlatformToPosition()].transform.position.x < platformGen.transform.position.x; NextPlatformToPosition())
		{	
			this.platforms[nextPlatformToPosition].transform.position = new Vector2(
																		Random.Range(this.platforms[PrevPlatformToPosition()].GetComponent<SpriteRenderer>().bounds.max.x + 10, this.platforms[PrevPlatformToPosition()].transform.position.x + 15), 
																		Random.Range(this.platforms[PrevPlatformToPosition()].GetComponent<SpriteRenderer>().bounds.max.y - 6, this.platforms[PrevPlatformToPosition()].transform.position.y + 6));
			this.platforms[nextPlatformToPosition].transform.position = new Vector2(this.platforms[nextPlatformToPosition].transform.position.x, Mathf.Clamp(this.platforms[nextPlatformToPosition].transform.position.y, 40.0f, 75.0f));

			if(this.monsters[PrevMonsterToPosition()].transform.position.x < platformGen.transform.position.x){
				this.monsters[nextMonsterToPosition].transform.position = new Vector2(
																					this.monsters[PrevMonsterToPosition()].transform.position.x + Random.Range(10.0f, 20.0f),
																				 	ground.transform.position.y + 15.7f
																				);
				NextMonsterToPosition();
			}

			if(Random.Range(0.0f,1.0f) < 0.1f)
				MakeItem();
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

	public void MakeMonster()
	{
		GameObject monster = Instantiate(monsterPrefab);
		monster.name = "Monster";
		this.monsters.Add(monster);
	}

	public void MakePlatform()
	{
		GameObject platform = Instantiate(platformPrefab);
		platform.name = "Platform";
		this.platforms.Add(platform);
		
	}

	private void PositionNextPlatform()
	{
		
	}

	public void MakeItem()
	{
		GameObject item = null;
		float randomValue = Random.Range(0.0f, 1.0f);
		if(randomValue <= 0.3f){
			item = Instantiate(HpPotionPrefab);
			item.name = "HpPotion";
		}else if (randomValue > 0.3f && randomValue <= 0.8f){
			item = Instantiate(ManaPotionPrefab);
			item.name = "ManaPotion";
		}
		if(item != null){
			item.transform.position = this.platforms[nextPlatformToPosition].transform.position + (Vector3.up * 3);
			this.items.Add(item);
		}
	}

	/*public void SetPlayerPlatform(GameObject platform)
	{
		for(int i = 0; i < platforms.Count; i++)
			if (platform == platforms[i])
			{
				this.nextPlatform = i;
				return;
			}
	}*/

	// ######### Utility funcitons #########

	void NextPlatform()
	{
		nextPlatform = ++nextPlatform % platforms.Count;
	}

	void NextPlatformToPosition()
	{
		nextPlatformToPosition = mod(++nextPlatformToPosition, platforms.Count);
	}

	int PrevPlatformToPosition()
	{
		return mod(nextPlatformToPosition - 1, platforms.Count);
	}

	void NextMonsterToPosition()
	{
		nextMonsterToPosition = mod(++nextMonsterToPosition, monsters.Count);
	}

	int PrevMonsterToPosition()
	{
		return mod(nextMonsterToPosition - 1, monsters.Count);
	}

	int mod(int x, int m)
	{	
    	return (x%m + m)%m;
	}
}
