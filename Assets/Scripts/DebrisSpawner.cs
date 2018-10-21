using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawner : MonoBehaviour {
	public GameObject prefabRock;
	public GameObject prefabDeadSat0;
	public GameObject prefabMicroMet;
	public GameObject prefabSatPanel;
	public GameObject prefabUFO;
	public GameObject prefabToothbrush;
	public GameObject prefabBolt;
	
	public float spawnCooldown;
	private float spawnTimer = 0.0f;
	
	void Start () {
		spawnTimer = Random.Range(0.0f, spawnCooldown);
	}
	
	void Update ()
	{
		spawnTimer += Time.deltaTime;
		if (spawnTimer >= spawnCooldown)
		{
			spawnTimer = Random.Range(0.0f, spawnCooldown - 1.0f);
			SpawnDebris();
		}
	}
	
	private void SpawnDebris()
	{
		Vector3 spawnPos = new Vector3(
			transform.position.x,
			transform.position.y,
			0.0f);
		GameObject o = null;
		float roll = Random.Range(0.0f, 1.0f);
		// if (roll < 0.125f)
		// {
			// o = Instantiate(
				// prefabSatPanel,
				// spawnPos,
				// Quaternion.Euler(0.0f, 0.0f, Random.Range(0, 359))).gameObject;
		// }
		if (roll < 0.167f)
		{
			o = Instantiate(
				prefabSatPanel,
				spawnPos,
				Quaternion.Euler(0.0f, 0.0f, Random.Range(0, 359))).gameObject;
		}
		else if (roll < 0.333f)
		{
			o = Instantiate(
				prefabDeadSat0,
				spawnPos,
				Quaternion.Euler(0.0f, 0.0f, Random.Range(0, 359))).gameObject;
		}
		else if (roll < 0.5f)
		{
			o = Instantiate(
				prefabUFO,
				spawnPos,
				Quaternion.Euler(0.0f, 0.0f, Random.Range(-90.0f, 90.0f))).gameObject;
		}
		else if (roll < 0.667f)
		{
			o = Instantiate(
				prefabToothbrush,
				spawnPos,
				Quaternion.Euler(0.0f, 0.0f, Random.Range(0, 359))).gameObject;
		}
		else if (roll < 0.833f)
		{
			o = Instantiate(
				prefabBolt,
				spawnPos,
				Quaternion.Euler(0.0f, 0.0f, Random.Range(0, 359))).gameObject;
		}
		else
		{
			o = Instantiate(
				prefabRock,
				spawnPos,
				Quaternion.Euler(0.0f, 0.0f, Random.Range(0, 359))).gameObject;
		}
		// o.transform.localScale = new Vector3(
			// o.transform.localScale.x * transform.localScale.x,
			// o.transform.localScale.y * transform.localScale.y,
			// 1.0f);
	}
}
