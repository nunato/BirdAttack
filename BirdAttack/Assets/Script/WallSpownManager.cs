using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSpownManager : MonoBehaviour
{
	public GameObject wallObject;
	public Transform[] spownPoints;
	public float spownSpeed_sec = 1.0f;

	void Start ()
	{
		StartCoroutine( "WallSpown" );
	}

	private IEnumerator WallSpown()
	{
		while( true ){
			int i = Random.Range(0, spownPoints.Length );
			Instantiate( wallObject, spownPoints[i].position, Quaternion.identity );
			yield return new WaitForSeconds( spownSpeed_sec );
		}
	}
}
