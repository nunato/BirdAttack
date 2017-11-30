using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionManager : MonoBehaviour
{
	private Vector3 mouseDownPosition = Vector3.zero;
	private PlayerMoveManager playerMove;

	void Awake()
	{
		GameObject PlayerObj = GameObject.Find( "Player" );
		playerMove = PlayerObj.GetComponent<PlayerMoveManager>();
	}

	void Update()
	{
		if( Input.GetMouseButtonDown(0) ){
			mouseDownPosition = Input.mousePosition;
		}

		if( Input.GetMouseButtonUp(0) ){
			Vector3 mouseUpPosition = Input.mousePosition;
			Debug.Log( "DownPosition" + mouseDownPosition );
			Debug.Log( "UpPosition" + mouseUpPosition );

			Vector3 tmpPosition = mouseDownPosition - mouseUpPosition;
			Vector3 newPosition;
			newPosition.x = tmpPosition.x;
			newPosition.y = tmpPosition.y;
			newPosition.z = 0;
			Debug.Log( "newPosition" + newPosition );

			playerMove.ShootPlayer( newPosition );
		}
	}
}
