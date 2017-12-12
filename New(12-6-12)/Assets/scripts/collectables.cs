using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectables : MonoBehaviour {

	private stat health;

	private void Awake()
	{
		health.Initialize ();	
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			Destroy (gameObject);
			health.CurrentVal += 10;
		}

	}
}
