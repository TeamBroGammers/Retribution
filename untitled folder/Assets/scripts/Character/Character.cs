using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
	public Animator anim{ get; private set;}
	protected Vector2 bulletPos;
	[SerializeField]
	protected int health;
	public abstract bool IsDead{ get;}

	[SerializeField]
	protected float movementSpeed;
	protected bool facingRight;
	[SerializeField]
	private GameObject BulletPrefab;
	// Use this for initialization
	public virtual void Start () {
		facingRight = true;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void ChangeDirection()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public virtual void fire()
	{
		bulletPos = transform.position;
		if (facingRight) 
		{
			bulletPos += new Vector2 (+1f, -0.30f);
			GameObject tmp= (GameObject)Instantiate (BulletPrefab, bulletPos, Quaternion.Euler(0,0,-90));
			tmp.GetComponent<Bullet> ().Initialize (Vector2.right);
		}
		else 
		{
			bulletPos += new Vector2 (-1f, -0.30f);
			GameObject tmp=	(GameObject)Instantiate (BulletPrefab, bulletPos, Quaternion.Euler(0,0,90));
			tmp.GetComponent<Bullet> ().Initialize (Vector2.left);
		}
	}
	public abstract IEnumerator TakeDamage ();

	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Bullet") 
		{
			StartCoroutine (TakeDamage ());
		}
	}
}
