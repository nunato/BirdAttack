using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
	public float ShootSpeed = 10f;

	private Rigidbody rbyPlayer;
	private bool fShoot = false;
	private bool fPlayerMove = false;
	private Vector3 ShootVectol = Vector3.zero;

	void Start()
	{
		rbyPlayer = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		/* 最初の発射 */
		if( fShoot == true ){
			fShoot = false;
			fPlayerMove = true;

			rbyPlayer.AddForce( ShootVectol * ShootSpeed, ForceMode.Acceleration );
		}

		/* 発射後の移動 */
		if( fPlayerMove == true ){

		}
	}

	public void ShootPlayer( Vector3 DragPosition )
	{
		fShoot = true;
		rbyPlayer.useGravity = true;
		ShootVectol = DragPosition;
	}

}
