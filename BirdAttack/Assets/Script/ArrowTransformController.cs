using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTransformController : MonoBehaviour
{
	public float MaxArrowLength = 250;

	private float panelWidth;
	private RectTransform panelRect;
	private Vector3 playerPosition;

	void Start()
	{
		panelRect = GetComponent<RectTransform>();
		Vector2 panelSize = panelRect.sizeDelta;
		panelWidth = panelSize.x;

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

		/* 長さを求める */
		float panelHeight = Mathf.Sqrt( Mathf.Pow( diffx, 2) + Mathf.Pow( diffy, 2));

		if( panelHeight > MaxArrowLength){
			panelHeight = MaxArrowLength;
		}

		/* 2Dベクトルから角度を求める */
		/* 右方向にX、上方向にYとする */
		float rot = Mathf.Atan2( diffx, diffy ) * 180 / Mathf.PI;
		/* ベクトルと正反対の方向に飛ぶので角度を逆転する */
		rot = rot + 180;

		panelRect.position = Camera.main.WorldToScreenPoint( playerPosition );
		panelRect.sizeDelta = new Vector2( panelWidth, panelHeight );
		panelRect.rotation = Quaternion.Euler( 0, -180, rot );
	}
}
