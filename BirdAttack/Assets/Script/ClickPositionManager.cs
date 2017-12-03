using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickPositionManager : MonoBehaviour
{
	private Vector3 mouseDownPosition = Vector3.zero;
	private PlayerMoveManager playerMove;
	private ArrowTransformController arrowController;

	void Awake()
	{
		GameObject PlayerObj = GameObject.Find( "Player" );
		playerMove = PlayerObj.GetComponent<PlayerMoveManager>();

		GameObject arrowTransformController = GameObject.Find("ArrowPanel");
		arrowController = arrowTransformController.GetComponent<ArrowTransformController>();
	}

	void Update()
	{
		if( Input.GetMouseButtonDown(0) ){
			mouseDownPosition = Input.mousePosition;
			mouseDownPosition.z = 0;

			arrowController.SetPanelActive( true );
		}

		if( Input.GetMouseButton(0) ){
			arrowController.PanelTransformUpdate( Input.mousePosition, mouseDownPosition );
		}

		if( Input.GetMouseButtonUp(0) ){
			arrowController.SetPanelActive( false );

			Vector3 mouseUpPosition = Input.mousePosition;
			mouseUpPosition .z = 0;
			Debug.Log( "DownPosition" + mouseDownPosition );
			Debug.Log( "UpPosition" + mouseUpPosition );

			Vector3 newPosition = mouseDownPosition - mouseUpPosition;
			Debug.Log( "newPosition" + newPosition );

			playerMove.ShootPlayer( newPosition );
		}
	}
}
