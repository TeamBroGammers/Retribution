using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerControlMovement : MonoBehaviour {


	public float speed;
	public float jump;
	float moveVelocity;
	bool grounded = false;

	// Use this for initialization
	void Start () {
		
		
	}

	void onTriggerEnter(){grounded = true;}
	void onTriggerExit(){grounded = false;}
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Space) || Input.GetKeyDown (KeyCode.W)) 
		{
			if (grounded)
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jump);
		}
	}
}
