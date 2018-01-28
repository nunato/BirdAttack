using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootMoveManager : MonoBehaviour
{
	public float ShootSpeed = 10f;

	private PlayerStatusManager PlayerState;
	private Rigidbody rbyPlayer;
	private Vector3 ShootVectol;

	void Start()
	{
		GameObject GameManager = GameObject.Find("GameManager");
		PlayerState = GameManager.GetComponent<PlayerStatusManager>();
		rbyPlayer = GetComponent<Rigidbody>();
		ShootVectol = Vector3.zero;
	}

	void FixedUpdate()
	{
		/* マウスが放された時一度だけ力を加えてプレイヤーを動かす */
		if( PlayerState.PlayerStatus == PLAYER_STATUS_T.SHOOT ){
			PlayerState.PlayerStatus = PLAYER_STATUS_T.MOVE;
			rbyPlayer.AddForce( ShootVectol * ShootSpeed, ForceMode.Acceleration );
		}
	}

	public void ShootPlayer( Vector3 DragPosition )
	{
		PlayerState.PlayerStatus = PLAYER_STATUS_T.SHOOT;
		rbyPlayer.useGravity = true;
		ShootVectol = DragPosition;
	}

}
