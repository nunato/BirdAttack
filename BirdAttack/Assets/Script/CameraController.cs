using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	private GameObject PlayerObj;
	private Vector3 PlayerOffset;

	void Start()
	{
		PlayerObj = GameObject.Find("Player");
		PlayerOffset = transform.position - PlayerObj.transform.position;
	}

	void Update()
	{
		if( PlayerObj != null ){
			Vector3 newPosition = transform.position;
			newPosition.x = PlayerObj.transform.position.x + PlayerOffset.x;
			transform.position = newPosition;
		}
	}
}
