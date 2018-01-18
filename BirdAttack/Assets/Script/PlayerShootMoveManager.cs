using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootMoveManager : MonoBehaviour
{
	public float ShootSpeed = 10f;

	private GamePlaySequenceManager GameState;
	private Rigidbody rbyPlayer;
	private Vector3 ShootVectol;

	void Start()
	{
		GameObject GameManager = GameObject.Find("GameManager");
		GameState = GameManager.GetComponent<GamePlaySequenceManager>();
		rbyPlayer = GetComponent<Rigidbody>();
		ShootVectol = Vector3.zero;
	}

	void FixedUpdate()
	{
		/* マウスが放された時一度だけ力を加えてプレイヤーを動かす */
		if( GameState.PlayerState == GameSequenceState.SHOOT ){
			GameState.PlayerState = GameSequenceState.MOVE;
			rbyPlayer.AddForce( ShootVectol * ShootSpeed, ForceMode.Acceleration );
		}
	}

	public void ShootPlayer( Vector3 DragPosition )
	{
		GameState.PlayerState = GameSequenceState.SHOOT;
		rbyPlayer.useGravity = true;
		ShootVectol = DragPosition;
	}

}
