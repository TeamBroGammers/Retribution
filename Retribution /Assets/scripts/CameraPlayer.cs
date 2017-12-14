using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayer : MonoBehaviour {

	[SerializeField]
	private float xMaxR;

	[SerializeField]
	private float yMaxT;

	[SerializeField]
	private float xMinL;

	[SerializeField]
	private float yMinB;

	private Transform target;

	void Start (){
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	void LateUpdate () 
	{
		transform.position = new Vector3 ( Mathf.Clamp(target.transform.position.x,xMinL,xMaxR),Mathf.Clamp(target.transform.position.y,yMinB,yMaxT),transform.position.z);
	}

}

