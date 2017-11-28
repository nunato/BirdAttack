using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMoveManager : MonoBehaviour
{
	public float speed;

	private Rigidbody rbyWall;

	void Start()
	{
		rbyWall = GetComponent<Rigidbody>();
	}

	void Update()
	{
		rbyWall.velocity = new Vector3( speed , 0, 0 );
	}
}
