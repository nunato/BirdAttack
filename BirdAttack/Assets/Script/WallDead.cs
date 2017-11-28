using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallDead : MonoBehaviour
{
	public int Point = 1;

	private float deadArea = -10;

	void Update()
	{
		if( transform.position.x < deadArea ){
			Destroy( gameObject );
			ScoreManager.AddScore(Point);
		}
	}
}
