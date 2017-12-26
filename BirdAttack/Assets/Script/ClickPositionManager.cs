﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * クリックしたポジションと放したポジションを管理し、
 * 2点のベクトルを求めてプレイヤーを動かすクラス
 */
public class ClickPositionManager : MonoBehaviour
{
	private Vector3 mouseDownPosition = Vector3.zero;
	private PlayerMoveManager playerMove;
	private ArrowTransformController arrowController;

	/* 
	 * 初期化関数
	 * プレイヤーオブジェクトへの参照と矢印アイコンの参照
	 */
	void Awake()
	{
		GameObject PlayerObj = GameObject.Find( "Player" );
		playerMove = PlayerObj.GetComponent<PlayerMoveManager>();

		GameObject arrowTransformController = GameObject.Find("ArrowPanel");
		arrowController = arrowTransformController.GetComponent<ArrowTransformController>();
	}

	void Update()
	{
		/* クリックポジションを取得して矢印アイコンを表示する */
		if( Input.GetMouseButtonDown(0) ){
			mouseDownPosition = Input.mousePosition;
			mouseDownPosition.z = 0;

			arrowController.SetPanelActive( true );
		}

		/* クリック中のポジションを取得し、矢印アイコンのサイズと角度を変更する */
		if( Input.GetMouseButton(0) ){
			arrowController.PanelTransformUpdate( Input.mousePosition, mouseDownPosition );
		}

		/* 放したポジションを取得し、2点のベクトルを利用してプレイヤーを動かす */
		if( Input.GetMouseButtonUp(0) ){
			arrowController.SetPanelActive( false );

			Vector3 mouseUpPosition = Input.mousePosition;
			mouseUpPosition .z = 0;
//			Debug.Log( "DownPosition" + mouseDownPosition );
//			Debug.Log( "UpPosition" + mouseUpPosition );

			Vector3 newPosition = mouseDownPosition - mouseUpPosition;

			playerMove.ShootPlayer( newPosition );
		}
	}
}
