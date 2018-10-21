using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour {
	public float spawnSpeedMin;
	public float spawnSpeedMax;
	private float speed;
	
	public float spawnAngularVelocityMin;
	public float spawnAngularVelocityMax;
	private float angularVelocity;

	// Use this for initialization
	void Start () {
		speed = Random.Range(spawnSpeedMin, spawnSpeedMax);
		angularVelocity = Random.Range(spawnAngularVelocityMin, spawnAngularVelocityMax);
	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
		transform.Rotate(0.0f, 0.0f, angularVelocity * Time.deltaTime);
		
		Camera cam = Camera.main;
		if (transform.position.x < cam.ScreenToWorldPoint(new Vector3(-Screen.width / 2, 0.0f, 0.0f)).x)
		{
			Destroy(gameObject);
		}
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		Debris refDebris = other.gameObject.GetComponent<Debris>();
		if (refDebris)
		{
			if (other.transform.position.x < transform.position.x)
			{
				refDebris.speed = speed + 2.0f;
			}
			else
			{
				speed = refDebris.speed + 2.0f;
			}
		}
		
		// if (other.transform.position.x < transform.position.x)
		// {
			// other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 10.0f, ForceMode2D.Impulse);
		// }
		// else
		// {
			// gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.left * 10.0f, ForceMode2D.Impulse);
		// }
	}
}
