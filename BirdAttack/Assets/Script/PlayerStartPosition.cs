using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
	public GameObject PlayerPosition;

	private PlayerStatusManager PlayerState;
	private Rigidbody rbyPlayer;

	void Start()
	{
		transform.position = PlayerPosition.transform.position;
		GameObject GameManager = GameObject.Find("GameManager");
		PlayerState = GameManager.GetComponent<PlayerStatusManager>();
		rbyPlayer = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if( PlayerState.PlayerStatus == PLAYER_STATUS_T.MOVE	&&
			rbyPlayer.IsSleeping( ) == true						){
			PlayerState.PlayerStatus = PLAYER_STATUS_T.IDLE;
			transform.position = PlayerPosition.transform.position;
			rbyPlayer.useGravity = false;
		}
	}
}
