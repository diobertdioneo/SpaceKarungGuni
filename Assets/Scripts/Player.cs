using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public float speed = 10.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("w"))
		{
			transform.Translate(Vector3.up * Time.deltaTime * speed);
		}
		else if (Input.GetKey("s"))
		{
			transform.Translate(Vector3.down * Time.deltaTime * speed);
		}
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		gameObject.GetComponent<AudioSource>().Play();
		Destroy(other.gameObject);
	}
}
