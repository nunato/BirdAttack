using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockDeleat : MonoBehaviour
{
	public float DeleatTimeSec = 2.0f;

	void OnCollisionEnter( Collision other )
	{
		if( other.gameObject.tag == "Player" ){
			Destroy( gameObject, DeleatTimeSec );
		}
	}

}
