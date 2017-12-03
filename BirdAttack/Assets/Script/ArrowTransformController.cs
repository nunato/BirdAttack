using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTransformController : MonoBehaviour
{
	public float panelWidth = 50;

	private RectTransform panelRect;
	private Vector3 playerPosition;

	void Start()
	{
		panelRect = GetComponent<RectTransform>();
		panelRect.sizeDelta = new Vector2( panelWidth, 0 );

		GameObject PlayerObj = GameObject.Find("Player");
		playerPosition = PlayerObj.transform.position;

		gameObject.SetActive( false );
	}

	public void SetPanelActive( bool IsActive )
	{
		gameObject.SetActive( IsActive );
	}

	/* ドラッグ量に応じて矢印の角度と長さを変化させる */
	public void PanelTransformUpdate( Vector3 DownPosition, Vector3 DragPosition )
	{
		float diffx = DownPosition.x - DragPosition.x;
		float diffy = DownPosition.y - DragPosition.y;
		//長さを求める
		float panelHeight = Mathf.Sqrt( Mathf.Pow( diffx, 2) + Mathf.Pow( diffy, 2));
		Debug.Log( "panelHeight" + panelHeight );


		//角度を求める

		panelRect.position = Camera.main.WorldToScreenPoint( playerPosition );
		panelRect.sizeDelta = new Vector2( panelWidth, panelHeight );
	}
}
