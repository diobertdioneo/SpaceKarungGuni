using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatePlay : MonoBehaviour {
	public GameObject prefabDebrisSpawner;
	private List<GameObject> spawners = new List<GameObject>();
	private int numSpawners = 3;
	
	public GameObject prefabPlayer;
	private GameObject player = null;
	
	public GameObject prefabEarth;
	public GameObject background;
	
	private float screenScale = 1.0f;
	private float worldScale = 1.0f;
	
	void Awake()
	{
	}
	
	void Start ()
	{
		//screenScale = Screen.width / 1920.0f;
		InitPlayer();
		InitEarth();
		InitSpawners();
	}
	
	private float elapsedTime = 0.0f;
	void Update ()
	{
		// Handle input
		if (Input.GetKeyDown("escape"))
		{
			Application.Quit();
		}
		
		// Perform updates
		elapsedTime += Time.deltaTime;
		worldScale = 1.0f + elapsedTime * 0.005f;
		if (worldScale > 1.5f)
		{
			worldScale = 1.5f;
		}
		if (worldScale > 1.2f && numSpawners < 4)
		{
			numSpawners = 4;
			InitSpawners();
		}
		if (worldScale > 1.4f && numSpawners < 5)
		{
			numSpawners = 5;
			InitSpawners();
		}
		
		Camera mainCam = Camera.main;
		mainCam.orthographicSize = 5.0f * worldScale;
		background.transform.localScale = new Vector3(0.64f * worldScale, 0.64f * worldScale, 1.0f);
		
		
		// Update player position
		{
			Vector3 pos = player.transform.position;
			Vector3 newPos = mainCam.ScreenToWorldPoint(
				new Vector3(0.1f * Screen.width, Screen.height / 2, 10.0f));
			player.transform.position = new Vector3(newPos.x, pos.y, pos.z);
		}
	}
	
	private void InitPlayer()
	{
		Camera cam = Camera.main;
		player = Instantiate(
			prefabPlayer,
			cam.ScreenToWorldPoint(new Vector3(0.1f * Screen.width, Screen.height / 2, 10.0f)),
			Quaternion.identity).gameObject;
		// player.transform.localScale = new Vector3(
			// player.transform.localScale.x * screenScale,
			// player.transform.localScale.y * screenScale,
			// 1.0f);
	}
	
	private void InitEarth()
	{
		Camera cam = Camera.main;
		GameObject o = Instantiate(
			prefabEarth,
			cam.ScreenToWorldPoint(new Vector3(Screen.width / 2, -Screen.height * 0.4f, 11.0f)),
			Quaternion.identity).gameObject;
		// o.transform.localScale = new Vector3(
			// o.transform.localScale.x * screenScale,
			// o.transform.localScale.y * screenScale,
			// 1.0f);
	}
	
	private void InitSpawners()
	{
		foreach (var spawner in spawners)
		{
			Destroy(spawner);
		}
		spawners.Clear();
		
		Camera cam = Camera.main;
		float verticalSpread = 0.5f * worldScale;
		float yInterval = verticalSpread / (numSpawners - 1);
		float currY = (1.0f - verticalSpread) * 0.5f;
		for (int i = 0; i < numSpawners; ++i)
		{
			GameObject s = Instantiate(
				prefabDebrisSpawner,
				cam.ScreenToWorldPoint(new Vector3(worldScale * Screen.width, currY * Screen.height, 0.0f)),
				Quaternion.identity).gameObject;
			//s.transform.localScale = new Vector3(screenScale, screenScale, 1.0f);
			s.GetComponent<DebrisSpawner>().spawnCooldown = 8.0f - numSpawners;
			spawners.Add(s);
			currY += yInterval;
		}
	}
}
