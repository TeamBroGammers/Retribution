using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character {
	private IEnemyState currentState;
	public GameObject Target{ get; set;}
	[SerializeField]
	private float meleeRange;
	[SerializeField]
	private float ShootRange;
	public bool InMeleeRange
	{
		get
		{
			if (Target != null) 
			{
				return Vector2.Distance (transform.position, Target.transform.position) <= meleeRange;
			}
			return false;
		}
	}
	public bool InShootRange
	{
		get
		{
			if (Target != null) 
			{
				return Vector2.Distance (transform.position, Target.transform.position) <= ShootRange;
			}
			return false;
		}
	}
	public override void Start()
	{
		base.Start();
		ChangeState(new IdleState());
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (!IsDead) {//////MIGHT NEED TO MAKE ANIMATION FOR WHEN THE ENEMY IS HURT******
			currentState.Execute ();
			LookAtTarget ();
		}
		}
	private void LookAtTarget()
	{
		if (Target != null) 
		{
			float xdir = Target.transform.position.x - transform.position.x;
			if (xdir < 0 && facingRight || xdir > 0 && !facingRight) 
			{
				ChangeDirection ();
			}
		}
	}
	public void ChangeState(IEnemyState newState)
	{
		if (currentState != null) 
		{
			currentState.Exit ();
		}
		currentState = newState;
		currentState.Enter (this);
	}
	public void Move()
	{
		bool walking = true;
		anim.SetBool ("Walking", walking);
		transform.Translate(GetDirection()*(movementSpeed*Time.deltaTime));
	}
	public Vector2 GetDirection()
	{
		return facingRight ? Vector2.right : Vector2.left;
	}
	public override void OnTriggerEnter2D(Collider2D other)
	{
		base.OnTriggerEnter2D (other);
		currentState.OnTriggerEnter (other);
	}
	public override IEnumerator TakeDamage()
	{
		health -= 10;
		if (!IsDead) {
			// will show enemy dying
		} 
		else 
		{
			yield return null;
		}
	}
	public override bool IsDead
	{
		get
		{
			return health <= 0;
		}
	}
}
