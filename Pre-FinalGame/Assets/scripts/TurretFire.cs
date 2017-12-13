using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretFire : MonoBehaviour {

	protected Animator anim;

	[SerializeField]
	protected Transform bulletPos;
	[SerializeField]
	private GameObject BulletPrefab;
	// Use this for initialization
	private float fireTimer;
	private float fireCoolDown=1;
	private bool canFire=true;
	[SerializeField]
	protected int health;
	void Start () {
		anim = GetComponent<Animator>();
		GetComponent<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	Fire ();
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
		GameObject tmp=	(GameObject)Instantiate (BulletPrefab, bulletPos.position, Quaternion.Euler(0,0,90));
		tmp.GetComponent<Bullet> ().Initialize (Vector2.left);
	}
}

public void OnTriggerEnter2D(Collider2D other)
{
		if (other.tag == "Bullet") 
		{
			health -= 10;
		}
		if (health <= 0) 
		{
			anim.SetTrigger ("IsDead");
			Destroy (gameObject, 2f);

		}
	}

}