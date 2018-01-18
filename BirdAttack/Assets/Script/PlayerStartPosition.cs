using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPosition : MonoBehaviour
{
	public GameObject PlayerPosition;

	private GamePlaySequenceManager GameState;
	private Rigidbody rbyPlayer;

	void Start()
	{
		transform.position = PlayerPosition.transform.position;
		GameObject GameManager = GameObject.Find("GameManager");
		GameState = GameManager.GetComponent<GamePlaySequenceManager>();
		rbyPlayer = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if( GameState.PlayerState == GameSequenceState.MOVE	&&
			rbyPlayer.IsSleeping( ) == true					){
			GameState.PlayerState = GameSequenceState.IDLE;
			transform.position = PlayerPosition.transform.position;
			rbyPlayer.useGravity = false;
		}
	}
}
