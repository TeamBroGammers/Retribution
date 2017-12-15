using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {
	public Animator anim{ get; private set;}
	[SerializeField]
	protected Transform bulletPos;
	[SerializeField]
	protected int health;
	public abstract bool IsDead{ get;}
	private EdgeCollider2D SwordCollider;
	[SerializeField]
	protected float movementSpeed;
	protected bool facingRight;
	[SerializeField]
	private List<string> damageSources;
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
	public abstract IEnumerator TakeDamage ();
	public abstract IEnumerator GetHealth ();
	public abstract IEnumerator GetEnergy ();
	public void ChangeDirection()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
	public virtual void fire()
	{
		if (facingRight) 
		{
			
			GameObject tmp= (GameObject)Instantiate (BulletPrefab, bulletPos.position, Quaternion.Euler(0,0,-90));
			tmp.GetComponent<Bullet> ().Initialize (Vector2.right);
		}
		else 
		{
			
			GameObject tmp=	(GameObject)Instantiate (BulletPrefab, bulletPos.position, Quaternion.Euler(0,0,90));
			tmp.GetComponent<Bullet> ().Initialize (Vector2.left);
		}
	}

	public virtual void OnTriggerEnter2D(Collider2D other)
	{
		if (damageSources.Contains(other.tag)) 
		{
			StartCoroutine (TakeDamage ());
		}
		if (other.tag == "Health") 
		{
			StartCoroutine (GetHealth ());
		}
		if((other.tag=="Energy"))
			{
				StartCoroutine (GetEnergy());
			}
	}
}
