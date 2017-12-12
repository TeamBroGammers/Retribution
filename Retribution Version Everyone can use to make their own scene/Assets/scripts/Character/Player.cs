 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character {

	[SerializeField]
	private Transform[] groundPoints;
	[SerializeField]
	private float groundRadius;
	[SerializeField]
	private float jumpForce;
	[SerializeField]
	private LayerMask whatIsGround;
	[SerializeField]
	private bool airControl;
	private Rigidbody2D myRigidbody;
	public float fireRate = 0.5f;
	float nextFire = 0.0f;
	private bool isGrounded;
	private bool IsWalking;
	private bool jump;
	private bool attack;
	public override void Start()
	{
		
		base.Start ();
		myRigidbody=GetComponent<Rigidbody2D>();
	}
	void Update()
	{
		HandleInput ();
	}
	void FixedUpdate()
	{
		float horizontal = Input.GetAxis ("Horizontal"); 
		isGrounded = IsGrounded ();
		Movement(horizontal);	
		Flip (horizontal);
		HandleAttack();
		ResetValues();
	}
	private void Movement(float horizontal)
	{
		if(isGrounded||airControl)
		{
		myRigidbody.velocity = new Vector2 (horizontal * movementSpeed, myRigidbody.velocity.y);//Vector with an x value -1 and y of 0
		}
			if (horizontal!= 0) {
			IsWalking = true;
		} else {
			IsWalking = false;
		}
		anim.SetBool("IsWalking", IsWalking);
		if (isGrounded && jump) 
		{
			anim.ResetTrigger ("Land");
			anim.SetTrigger("Jump");
			isGrounded = false;
			myRigidbody.AddForce (new Vector2 (0, jumpForce));

		}
	}
	private void HandleAttack()
	{
		if (attack) 
		{
			myRigidbody.velocity = Vector2.zero;
			//Needs to add the attack
		}
	}
	void HandleInput()
	{
		if(Input.GetKeyDown(KeyCode.W))
			{
			jump = true;
			}
		if (Input.GetKeyDown (KeyCode.LeftShift)) 
		{
			attack = true;
		}
		if (Input.GetKey (KeyCode.Space) && Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			fire ();
		}
	}
	private void Flip(float horizontal)
	{
		if (horizontal > 0 && !facingRight || horizontal<0 && facingRight) 
		{
			ChangeDirection ();	
		}
	}
	private void ResetValues()
	{
		attack = false;
		jump = false;
	}
	private bool IsGrounded()
	{
		if (myRigidbody.velocity.y <= 0) 
		{
			foreach (Transform point in groundPoints) 
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRadius, whatIsGround);
					for(int i=0; i<colliders.Length;i++)
				{
					if(colliders[i].gameObject !=gameObject)
					{
						anim.ResetTrigger ("Jump");
						anim.SetTrigger ("Land");
						return true;
					}
				}
			}
		}
		return false;
	}
	public override IEnumerator TakeDamage()
	{
		
		health -= 10;
		if (!IsDead) {
			//ADD ANIMATION FOR GETTING HURT	
		}
		else 
		{
			yield return null;
		}
	}
	public override IEnumerator GetHealth()
	{
		health +=50;
		if (!IsDead) {
			// will show enemy getting hurt
		} 
		else 
		{
			//add death animation
			yield return null;
		}
	}
	public override bool IsDead
	{
		get
		{
			return health<=0;
		}
	}
}
