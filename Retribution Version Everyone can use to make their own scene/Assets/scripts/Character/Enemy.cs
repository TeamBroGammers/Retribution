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
	[SerializeField]
	private Transform leftEdge;
	[SerializeField]
	private Transform rightEdge;
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
		if (!IsDead) 
		{//////MIGHT NEED TO MAKE ANIMATION FOR WHEN THE ENEMY IS HURT******
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
		if (GetDirection ().x > 0 && transform.position.x < rightEdge.position.x || GetDirection ().x < 0 && transform.position.x > leftEdge.position.x) {

			bool walking = true;
			anim.SetBool ("Walking", walking);
			transform.Translate (GetDirection () * (movementSpeed * Time.deltaTime));
		}
		else if (currentState is PatrolState)
			{
				ChangeDirection ();
			}
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
			// will show enemy getting hurt
		} 
		else 
		{
			//add death animation
			anim.SetTrigger("IsDead");
			Destroy(gameObject,2f);
			yield return null;
		}
	}
	public override IEnumerator GetHealth()
	{
		
		health +=10;
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
			return health <= 0;
		}
	}

}
