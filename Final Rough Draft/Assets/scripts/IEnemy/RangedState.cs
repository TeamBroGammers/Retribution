using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IEnemyState {
	private Enemy enemy;
	private float fireTimer;
	private float fireCoolDown=1;
	private bool canFire=true;
	public void Execute()
	{
		Fire ();
		if (enemy.InMeleeRange) 
		{
			enemy.ChangeState (new MeleeState ());
		}
		if (enemy.Target != null) {
			enemy.Move ();
		} 
		else 
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
	private void Fire()
	{
		fireTimer += Time.deltaTime;
		if (fireTimer >= fireCoolDown) 
		{
			canFire = true;
			fireTimer=0;
		}
		if(canFire)
		{
			canFire = false;
			enemy.fire ();
		}
	}
}
