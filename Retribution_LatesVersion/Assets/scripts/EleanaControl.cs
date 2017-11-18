using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EleanaControl : MonoBehaviour {

	[SerializeField]
	private stat health;

	public float moveSpeed = 3f;
	float velX;
	float velY;
	bool facingRight = true;
	Rigidbody2D rigBody;
	Animator anim;
	bool IsWalking=false;
	public float jumpForce = 600f;
	public LayerMask theGround;
	public Transform groundCheck;
	bool IsOnTheGround = false;

	public GameObject bulletToLeft, bulletToRight;
	Vector2 bulletPos;
	public float fireRate = 0.5f;
	float nextFire = 0.0f;


	private void Awake()
	{
		health.Initialize ();	
	}

	// Use this for initialization
	void Start () 
	{
		rigBody = GetComponent<Rigidbody2D> ();	
		anim = GetComponent<Animator>();


	}
	// Update is called once per frame
	void Update () 
	{
		velX = Input.GetAxisRaw ("Horizontal");
		velY = rigBody.velocity.y;
		rigBody.velocity = new Vector2 (velX * moveSpeed,velY);


		if (velX != 0) {
			IsWalking = true;
		} else {
			IsWalking = false;
		}
		anim.SetBool ("IsWalking", IsWalking);

		IsOnTheGround = Physics2D.Linecast (transform.position, groundCheck.position,theGround);
		anim.SetBool ("IsOnTheGround",IsOnTheGround);
	
		if(IsOnTheGround && Input.GetKey(KeyCode.UpArrow))
		{
			velY = 0f;
			rigBody.AddForce (new Vector2 (0, jumpForce));
		}
		//if(Input.GetButtonDown("Fire1")&& Time.time > nextFire)
		if(Input.GetKey(KeyCode.Space)&& Time.time > nextFire)
		{
			nextFire = Time.time + fireRate;
			fire();
		}
		if(Input.GetKeyDown(KeyCode.Q))
		{
			health.CurrentVal -= 10;
		}
		if(Input.GetKeyDown(KeyCode.W))
		{
			health.CurrentVal += 10;
		}

	}

	void LateUpdate ()
	{
		Vector3 localScale = transform.localScale;
		if (velX > 0) 
		{
			facingRight = true;
		}
		else if(velX < 0)
		{
			facingRight = false;
		}
		if(((facingRight) && (localScale.x < 0))|| ((!facingRight) && (localScale.x > 0)))
		{	
			localScale.x *= -1;
		}
		transform.localScale = localScale; 

	}
	void fire()
	{
		bulletPos = transform.position;
		if (facingRight) {
			bulletPos += new Vector2 (+1f, -0.30f);
			Instantiate (bulletToRight, bulletPos, Quaternion.identity);
		} else {
			bulletPos += new Vector2 (-1f, -0.30f);
			Instantiate (bulletToLeft, bulletPos, Quaternion.identity);
		}
	}
}
