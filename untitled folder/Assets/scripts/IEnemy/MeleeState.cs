using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeState : IEnemyState {
	private Enemy enemy;
	private float attackTimer;
	private float attackCoolDown=3;
	private bool canAttack=true;
	public void Execute()
	{
		Attack ();
		if (enemy.InShootRange && !enemy.InMeleeRange)
		{
			enemy.ChangeState (new RangedState ());
		} 
		else if (!enemy.Target == null) 
		{
			enemy.ChangeState (new IdleState ());
		}
	}
	public void Enter(Enemy enemy)
	{
		this.enemy = enemy;
	}
	public void Exit()
	{
	}
	public void OnTriggerEnter (Collider2D other)
	{

	}
	private void Attack()
	{
		Debug.Log ("I will fire");
		attackTimer += Time.deltaTime;
		if (attackTimer >= attackCoolDown) 
		{
			Debug.Log ("I am firing");
			canAttack = true;
			attackTimer=0;
		}
		if(canAttack)
		{
			canAttack = false;
			//enemy.fire (); NEED TO FIX AND HAVE HIM JUST HURT THE PLAYER
		}
	}
}
