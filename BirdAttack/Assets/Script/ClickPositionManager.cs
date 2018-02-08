using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * クリックしたポジションと放したポジションを管理し、
 * 2点のベクトルを求めてプレイヤーを動かすクラス
 */
public class ClickPositionManager : MonoBehaviour
{
	private Vector3 mouseDownPosition = Vector3.zero;	/* クリック位置の記憶 */
	private PlayerShootMoveManager playerMove;			/* プレイヤーへの参照 */
	private ArrowTransformController arrowController;	/* 矢印アイコンの表示 */
	private PlayerStatusManager PlayerState;			/* プレイヤー状態への参照 */
	private ShootRemainManager ShootRemainCount;		/* 残数への参照 */
	private ClearFlagManager ClearFlag;					/* クリアフラグへの参照 */

	void Start()
	{
		GameObject PlayerObj = GameObject.Find("Player");
		playerMove = PlayerObj.GetComponent<PlayerShootMoveManager>();

		GameObject arrowTransformController = GameObject.Find("ArrowPanel");
		arrowController = arrowTransformController.GetComponent<ArrowTransformController>();

		GameObject GameManager = GameObject.Find("GameManager");
		PlayerState = GameManager.GetComponent<PlayerStatusManager>();
		ClearFlag = GameManager.GetComponent<ClearFlagManager>();

		GameObject RemainManager = GameObject.Find("RemainManager");
		ShootRemainCount = RemainManager.GetComponent<ShootRemainManager>();
	}

	void Update()
	{
		if( PlayerState.PlayerStatus != PLAYER_STATUS_T.IDLE	||
			ClearFlag.GameOver == true							){
			return;
		}

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

			Vector3 ShootVector = mouseDownPosition - mouseUpPosition;

			/* ベクトル上限に制限する */
			ShootVector = MaxShootPowerCheck.LimitShootVector( ShootVector );

			playerMove.ShootPlayer( ShootVector );
			ShootRemainCount.DecrementRemain();
		}
	}
}
