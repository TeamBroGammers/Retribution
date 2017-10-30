using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour {

	public int playerSpeed=10;
	public bool facingRight=true;
	public int playerJumpPower=160;
	private float moveX;
	bool onGround=false;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		player_move();

		
	}
	void player_move ()
	{
		moveX =Input.GetAxis("Horizontal");
		if(Input.GetButtonDown("Jump"))
		{
			Jump ();
		}
		if( moveX < 0.0f && facingRight== false)
		{
			FlipPlayer();
		}
		else if(moveX > 0.0f && facingRight== true)
		{
			FlipPlayer();
		
		}

		gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D> ().velocity.y);
	}
	void Jump()
	{
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
	}
		
	void FlipPlayer()
	{
		facingRight =! facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

}
