using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveManager : MonoBehaviour
{
	public float ShootSpeed = 10;
	public float ShootRotate = 30;

	private Rigidbody rbyPlayer;
	private bool fShoot = false;
	private bool fPlayerMove = false;

	void Start()
	{
		rbyPlayer = GetComponent<Rigidbody>();
	}

	void Update()
	{
		/* マウスが押されたとき、プレイヤーが発射されていない、動いていない */
		if( Input.GetMouseButtonDown(0) && fShoot == false && fPlayerMove == false ){
			fShoot = true;
		}
	}

	void FixedUpdate()
	{
		/* 最初の発射 */
		if( fShoot == true ){
			fShoot = false;
			fPlayerMove = true;

			rbyPlayer.AddForce( 10, 10, 0, ForceMode.VelocityChange );
		}

		/* 発射後の移動 */
		if( fPlayerMove == true ){

		}
	}

}
