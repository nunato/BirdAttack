using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLine : MonoBehaviour
{
	private LineRenderer lineRenderer;

	void Awake()
	{
		lineRenderer = gameObject.GetComponent<LineRenderer>();
	}

	public void Create( Vector3 StartPoint, Vector3 EndPoint )
	{
		//Input.mousePositionからはワールド座標系でくるため、
		//スクリーン座標系に変換する
		Vector3 StartPositoin = Camera.main.ScreenToWorldPoint( StartPoint );
		Vector3 EndPositoin = Camera.main.ScreenToWorldPoint( EndPoint );

		StartPositoin.z = 0;
		EndPositoin.z = 0;

			Debug.Log( "StartPositoin" + StartPositoin );
			Debug.Log( "EndPositoin" + EndPositoin );
//		lineRenderer.SetPosition( 0, StartPositoin );
//		lineRenderer.SetPosition( 1, EndPositoin );
	}

	public void Deleate()
	{
		lineRenderer.SetPosition( 0, Vector3.zero );
		lineRenderer.SetPosition( 1, Vector3.zero );
	}
}
