using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespownManager : MonoBehaviour
{
	public GameObject playerPrefab;
	public GameObject deadText;

	private bool IsPlayerDead;
	private bool IsPlayerReswoning;
//	private Vector3 spownPoint;
//	private CameraController cameraContlloer;
//	private GameObject player;

	public bool isPlayerDead
	{
		get{ return IsPlayerDead; }
		set{ IsPlayerDead = value; }
	}

	public bool isPlayerReswoning
	{
		get{ return IsPlayerReswoning; }
	}

	void Start()
	{
		IsPlayerDead = false;
		IsPlayerReswoning = false;
//		GameObject playerPosition = GameObject.FindGameObjectWithTag("Player");
//		spownPoint = playerPosition.transform.position;
//		GameObject camera = GameObject.FindGameObjectWithTag("MainCamera");
//		cameraContlloer = camera.GetComponent<CameraController>();
	}

	void Update()
	{
		if( Input.GetKeyDown( KeyCode.R ) && IsPlayerDead == true ){
//			player = Instantiate( playerPrefab, spownPoint, Quaternion.identity ) as GameObject;
			deadText.SetActive(false);
			IsPlayerDead = false;
			IsPlayerReswoning = true;
		}
	}

	void LateUpdate()
	{
		if( IsPlayerReswoning == true ){
//			cameraContlloer.RestartCameraContlloer( player );
			IsPlayerReswoning = false;
		}
	}

	public void ShowDeadText()
	{
		deadText.SetActive(true);
	}
}
