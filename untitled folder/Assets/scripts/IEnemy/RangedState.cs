using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedState : IEnemyState {
	private Enemy enemy;
	private float fireTimer;
	private float fireCoolDown=3;
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
		Debug.Log ("I will fire");
		fireTimer += Time.deltaTime;
		if (fireTimer >= fireCoolDown) 
		{
			Debug.Log ("I am firing");
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
