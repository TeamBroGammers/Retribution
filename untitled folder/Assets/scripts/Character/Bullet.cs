using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof (Rigidbody2D))]
public class Bullet : MonoBehaviour {

	[SerializeField]
	private float speed=10;
	private Rigidbody2D myRigidbody;
	private Vector2 direction;

	void Start () 
	{
		myRigidbody = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate()
	{
		myRigidbody.velocity=direction*speed;
	}
	// Update is called once per frame
	public void Initialize(Vector2 direction)
	{
		this.direction=direction;
	}
	void BecomeInvisible()
	{
		Destroy(gameObject);
	}
}
