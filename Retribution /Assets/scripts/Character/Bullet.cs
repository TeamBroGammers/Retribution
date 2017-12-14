using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Bullet : MonoBehaviour {

	[SerializeField]
	private float speed=20;
	private Rigidbody2D myRigidbody;
	private Vector2 direction;

	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{
		myRigidbody.velocity=direction*speed;
		BecomeInvisible();
	}
	// Update is called once per frame
	public void Initialize(Vector2 direction)
	{
		this.direction=direction;
	}
	void BecomeInvisible()
	{
		Destroy(gameObject,3f);
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if((other.tag == "Enemy"))
			{	
				Destroy(gameObject);
			}
	if((other.tag == "Player"))
	{	
		Destroy(gameObject);
	}
	}
}
